namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Exceptions;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Basic;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class TraktAuthentication
    {
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private TraktAuthorization _authorization;
        private TraktDevice _device;

        internal TraktAuthentication(TraktClient client)
        {
            Client = client;
            AntiForgeryToken = Guid.NewGuid().ToString();
            RedirectUri = DEFAULT_REDIRECT_URI;
        }

        public TraktClient Client { get; private set; }

        public string OAuthAuthorizationCode { get; set; }

        public TraktAuthorization Authorization
        {
            get { return _authorization = _authorization ?? new TraktAuthorization(); }
            set { _authorization = value; }
        }

        public TraktDevice Device
        {
            get { return _device = _device ?? new TraktDevice(); }
            set { _device = value; }
        }

        public string AntiForgeryToken { get; private set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; }

        public bool IsAuthorized => Authorization != null && Authorization.IsValid;

        public async Task<TraktAuthorization> RefreshAuthorizationAsync()
        {
            return await RefreshAuthorizationAsync(Authorization.RefreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken)
        {
            return await RefreshAuthorizationAsync(refreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId)
        {
            return await RefreshAuthorizationAsync(refreshToken, clientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret)
        {
            return await RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, RedirectUri);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            if (!IsAuthorized && (string.IsNullOrEmpty(refreshToken) || refreshToken.ContainsSpace()))
                throw new TraktAuthorizationException("not authorized");

            if (string.IsNullOrEmpty(refreshToken) || refreshToken.ContainsSpace())
                throw new ArgumentException("refresh token not valid", "refreshToken");

            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            ValidateRefreshTokenInput(clientId, clientSecret, redirectUri, grantType);

            var postContent = $"{{ \"refresh_token\": \"{refreshToken}\", \"client_id\": \"{clientId}\"," +
                              $" \"client_secret\": \"{clientSecret}\", \"redirect_uri\": \"{redirectUri}\"," +
                              $" \"grant_type\": \"{grantType}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthTokenUri}";
            var content = new StringContent(postContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(tokenUrl, content);

            HttpStatusCode responseCode = response.StatusCode;
            string responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;
            string reasonPhrase = response.ReasonPhrase;

            if (responseCode == HttpStatusCode.OK)
            {
                var token = default(TraktAuthorization);

                if (!string.IsNullOrEmpty(responseContent))
                    token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAuthorization>(responseContent));

                Client.Authentication.Authorization = token;
                return token;
            }
            else if (responseCode == HttpStatusCode.Unauthorized) // Invalid code
            {
                var error = default(TraktError);

                if (!string.IsNullOrEmpty(responseContent))
                    error = await Task.Run(() => JsonConvert.DeserializeObject<TraktError>(responseContent));

                var errorMessage = error != null ? ($"error on refreshing oauth access token\nerror: {error.Error}\n" +
                                                    $"description: {error.Description}")
                                                 : "unknown error";

                throw new TraktAuthenticationException(errorMessage)
                {
                    StatusCode = responseCode,
                    RequestUrl = tokenUrl,
                    RequestBody = postContent,
                    ServerReasonPhrase = reasonPhrase
                };
            }

            await ErrorHandling(response, tokenUrl, postContent);
            return default(TraktAuthorization);
        }

        public async Task RevokeAuthorizationAsync()
        {
            await RevokeAuthorizationAsync(Authorization.AccessToken, Client.ClientId);
        }

        public async Task RevokeAuthorizationAsync(string accessToken)
        {
            await RevokeAuthorizationAsync(accessToken, Client.ClientId);
        }

        public async Task RevokeAuthorizationAsync(string accessToken, string clientId)
        {
            if (!IsAuthorized && (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace()))
                throw new TraktAuthorizationException("not authorized");

            if (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace())
                throw new ArgumentException("access token not valid", "accessToken");

            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            var postContent = $"{{ \"access_token\": \"{accessToken}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);
            SetAuthorizationRequestHeaders(httpClient, accessToken, clientId);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthRevokeUri}";
            var content = new StringContent(postContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(tokenUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

                    throw new TraktAuthenticationException("error on revoking access token")
                    {
                        RequestUrl = tokenUrl,
                        RequestBody = postContent,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                }

                await ErrorHandling(response, tokenUrl, postContent);
            }
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void SetAuthorizationRequestHeaders(HttpClient httpClient, string accessToken, string clientId)
        {
            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, clientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{Client.Configuration.ApiVersion}");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private void ValidateRefreshTokenInput(string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", "clientSecret");

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", "redirectUri");

            if (string.IsNullOrEmpty(grantType))
                throw new ArgumentException("grant type not valid", "grantType");
        }

        private async Task ErrorHandling(HttpResponseMessage response, string requestUrl, string requestContent)
        {
            var responseContent = string.Empty;

            if (response.Content != null)
                responseContent = await response.Content.ReadAsStringAsync();

            var code = response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;

            switch (code)
            {
                case HttpStatusCode.NotFound:
                    throw new TraktNotFoundException("Resource not found")
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.BadRequest:
                    throw new TraktBadRequestException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.Conflict:
                    throw new TraktConflictException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.Forbidden:
                    throw new TraktForbiddenException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.MethodNotAllowed:
                    throw new TraktMethodNotFoundException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.InternalServerError:
                    throw new TraktServerException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.BadGateway:
                    throw new TraktBadGatewayException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)412:
                    throw new TraktPreconditionFailedException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)422:
                    throw new TraktValidationException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)429:
                    throw new TraktRateLimitException
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)503:
                case (HttpStatusCode)504:
                    throw new TraktServerUnavailableException("Service Unavailable - server overloaded (try again in 30s)")
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)520:
                case (HttpStatusCode)521:
                case (HttpStatusCode)522:
                    throw new TraktServerUnavailableException("Service Unavailable - Cloudflare error")
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestContent,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
            }

            throw new TraktAuthenticationException("unknown exception") { ServerReasonPhrase = reasonPhrase };
        }
    }
}
