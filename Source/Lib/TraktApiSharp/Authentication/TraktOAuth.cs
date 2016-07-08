namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Exceptions;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class TraktOAuth
    {
        internal TraktOAuth(TraktClient client)
        {
            Client = client;
        }

        public TraktClient Client { get; private set; }

        public string CreateAuthorizationUrl()
        {
            var clientId = Client.ClientId;
            var redirectUri = Client.Authentication.RedirectUri;

            return CreateAuthorizationUrl(clientId, redirectUri);
        }

        public string CreateAuthorizationUrl(string clientId)
        {
            var redirectUri = Client.Authentication.RedirectUri;
            return CreateAuthorizationUrl(clientId, redirectUri);
        }

        public string CreateAuthorizationUrl(string clientId, string redirectUri)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri);
            return BuildAuthorizationUrl(clientId, redirectUri);
        }

        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri, state);
            return BuildAuthorizationUrl(clientId, redirectUri, state);
        }

        public string CreateAuthorizationUrlWithDefaultState()
        {
            var clientId = Client.ClientId;
            var redirectUri = Client.Authentication.RedirectUri;
            var state = Client.Authentication.AntiForgeryToken;

            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        public string CreateAuthorizationUrlWithDefaultState(string clientId)
        {
            var redirectUri = Client.Authentication.RedirectUri;
            var state = Client.Authentication.AntiForgeryToken;
            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri)
        {
            var state = Client.Authentication.AntiForgeryToken;
            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync()
        {
            return await GetAuthorizationAsync(Client.Authentication.OAuthAuthorizationCode);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync(string code)
        {
            return await GetAuthorizationAsync(code, Client.ClientId, Client.ClientSecret, Client.Authentication.RedirectUri);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId)
        {
            return await GetAuthorizationAsync(code, clientId, Client.ClientSecret, Client.Authentication.RedirectUri);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId, string clientSecret)
        {
            return await GetAuthorizationAsync(code, clientId, clientSecret, Client.Authentication.RedirectUri);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId, string clientSecret, string redirectUri)
        {
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            ValidateAccessTokenInput(code, clientId, clientSecret, redirectUri, grantType);

            var postContent = $"{{ \"code\": \"{code}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

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

                var errorMessage = error != null ? ($"error on retrieving oauth access token\nerror: {error.Error}\n" +
                                                    $"description: {error.Description}")
                                                 : "unknown error";

                throw new TraktAuthenticationOAuthException(errorMessage)
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

        public async Task<TraktAuthorization> RefreshAuthorizationAsync()
        {
            return await Client.Authentication.RefreshAuthorizationAsync();
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken)
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId)
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret)
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, redirectUri);
        }

        public async Task RevokeAuthorizationAsync()
        {
            await Client.Authentication.RevokeAuthorizationAsync();
        }

        public async Task RevokeAuthorizationAsync(string accessToken)
        {
            await Client.Authentication.RevokeAuthorizationAsync(accessToken);
        }

        public async Task RevokeAuthorizationAsync(string accessToken, string clientId)
        {
            await Client.Authentication.RevokeAuthorizationAsync(accessToken, clientId);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private string CreateEncodedAuthorizationUri(string clientId, string redirectUri, string state = null)
        {
            var uriParams = new Dictionary<string, string>();

            uriParams["response_type"] = "code";
            uriParams["client_id"] = clientId;
            uriParams["redirect_uri"] = redirectUri;

            if (!string.IsNullOrEmpty(state))
                uriParams["state"] = state;

            var encodedUriContent = new FormUrlEncodedContent(uriParams);
            var encodedUri = encodedUriContent.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(encodedUri))
                throw new ArgumentException("authorization uri not valid");

            return $"?{encodedUri}";
        }

        private string BuildAuthorizationUrl(string clientId, string redirectUri, string state = null)
        {
            var encodedUriParams = CreateEncodedAuthorizationUri(clientId, redirectUri, state);
            var authorizationUrl = $"{TraktConstants.OAuthBaseAuthorizeUrl}/{TraktConstants.OAuthAuthorizeUri}{encodedUriParams}";

            return authorizationUrl;
        }

        private void ValidateAuthorizationUrlParameters(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", "redirectUri");
        }

        private void ValidateAuthorizationUrlParameters(string clientId, string redirectUri, string state)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri);

            if (string.IsNullOrEmpty(state) || state.ContainsSpace())
                throw new ArgumentException("state not valid", "state");
        }

        private void ValidateAccessTokenInput(string code, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(code) || code.ContainsSpace())
                throw new ArgumentException("code not valid", "code");

            ValidateAuthorizationUrlParameters(clientId, redirectUri);

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", "clientSecret");

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

            throw new TraktAuthenticationOAuthException("unknown exception") { ServerReasonPhrase = reasonPhrase };
        }
    }
}
