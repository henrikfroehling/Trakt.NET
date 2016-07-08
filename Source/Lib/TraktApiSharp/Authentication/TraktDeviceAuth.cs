namespace TraktApiSharp.Authentication
{
    using Core;
    using Exceptions;
    using Extensions;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class TraktDeviceAuth
    {
        internal TraktDeviceAuth(TraktClient client)
        {
            Client = client;
        }

        public TraktClient Client { get; private set; }

        public async Task<TraktDevice> GenerateDeviceAsync()
        {
            return await GenerateDeviceAsync(Client.ClientId);
        }

        public async Task<TraktDevice> GenerateDeviceAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceCodeUri}";
            var content = new StringContent(postContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(tokenUrl, content);

            if (!response.IsSuccessStatusCode)
                await ErrorHandling(response, tokenUrl, postContent, true);

            var responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

            var device = default(TraktDevice);

            if (!string.IsNullOrEmpty(responseContent))
                device = await Task.Run(() => JsonConvert.DeserializeObject<TraktDevice>(responseContent));

            Client.Authentication.Device = device;
            return device;
        }

        public async Task<TraktAuthorization> PollForAuthorizationAsync()
        {
            return await PollForAuthorizationAsync(Client.Authentication.Device, Client.ClientId, Client.ClientSecret);
        }

        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device)
        {
            return await PollForAuthorizationAsync(device, Client.ClientId, Client.ClientSecret);
        }

        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device, string clientId)
        {
            return await PollForAuthorizationAsync(device, clientId, Client.ClientSecret);
        }

        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device, string clientId, string clientSecret)
        {
            ValidateAccessTokenInput(device, clientId, clientSecret);

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceTokenUri}";

            HttpStatusCode responseCode = default(HttpStatusCode);
            string responseContent = string.Empty;
            string reasonPhrase = string.Empty;
            int totalExpiredSeconds = 0;

            while (totalExpiredSeconds < device.ExpiresInSeconds)
            {
                var content = new StringContent(postContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(tokenUrl, content);

                responseCode = response.StatusCode;
                reasonPhrase = response.ReasonPhrase;
                responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

                if (responseCode == HttpStatusCode.OK) // Success
                {
                    var token = default(TraktAuthorization);

                    if (!string.IsNullOrEmpty(responseContent))
                        token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAuthorization>(responseContent));

                    Client.Authentication.Authorization = token;
                    return token;
                }
                else if (responseCode == HttpStatusCode.BadRequest) // Pending
                {
                    await Task.Delay(device.IntervalInSeconds * 1000);
                    totalExpiredSeconds += device.IntervalInSeconds;
                    continue;
                }

                switch (responseCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new TraktAuthenticationDeviceException("Not Found - invalid device_code")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case HttpStatusCode.Conflict:   // Already Used
                        throw new TraktAuthenticationDeviceException("Already Used - user already approved this code")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case HttpStatusCode.Gone:       // Expired
                        throw new TraktAuthenticationDeviceException("Expired - the tokens have expired, restart the process")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case (HttpStatusCode)418:       // Denied
                        throw new TraktAuthenticationDeviceException("Denied - user explicitly denied this code")
                        {
                            StatusCode = (HttpStatusCode)418,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case (HttpStatusCode)429:       // Slow Down
                        throw new TraktAuthenticationDeviceException("Slow Down - your app is polling too quickly")
                        {
                            StatusCode = (HttpStatusCode)429,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                }

                await ErrorHandling(response, tokenUrl, postContent, true);
                break;
            }

            throw new TraktAuthenticationDeviceException("unknown exception") { ServerReasonPhrase = reasonPhrase };
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

        private void ValidateAccessTokenInput(TraktDevice device, string clientId, string clientSecret)
        {
            if (device == null)
                throw new ArgumentNullException("device must not be null", "device");

            if (device.IsExpiredUnused)
                throw new ArgumentException("device code expired unused", "device");

            if (!device.IsValid)
                throw new ArgumentException("device not valid", "device");

            if (device.DeviceCode.ContainsSpace())
                throw new ArgumentException("device code not valid", "device");

            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", "clientSecret");
        }

        private async Task ErrorHandling(HttpResponseMessage response, string requestUrl, string requestContent, bool handleAdditionalCodes)
        {
            var responseContent = string.Empty;

            if (response.Content != null)
                responseContent = await response.Content.ReadAsStringAsync();

            var code = response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;

            switch (code)
            {
                case HttpStatusCode.Unauthorized:
                    throw new TraktAuthorizationException
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

            if (handleAdditionalCodes)
            {
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
                    case (HttpStatusCode)429:
                        throw new TraktRateLimitException
                        {
                            RequestUrl = requestUrl,
                            RequestBody = requestContent,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                }
            }

            throw new TraktAuthenticationDeviceException("unknown error")
            {
                StatusCode = code,
                RequestUrl = requestUrl,
                RequestBody = requestContent,
                Response = responseContent,
                ServerReasonPhrase = reasonPhrase
            };
        }
    }
}
