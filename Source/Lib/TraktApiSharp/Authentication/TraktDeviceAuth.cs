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

            using (var content = new StringContent(postContent))
            using (var response = await httpClient.PostAsync(tokenUrl, content))
            {
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var device = await Task.Run(() => JsonConvert.DeserializeObject<TraktDevice>(data));

                    Client.Authentication.Device = device;

                    return device;
                }
                else
                {
                    var responseContent = string.Empty;

                    if (response.Content != null)
                        responseContent = await response.Content.ReadAsStringAsync();

                    throw new TraktAuthenticationDeviceException("error on generating authentication device")
                    {
                        StatusCode = statusCode,
                        RequestUrl = tokenUrl,
                        RequestBody = postContent,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync()
        {
            return await GetAccessTokenAsync(Client.Authentication.Device, Client.ClientId, Client.ClientSecret);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(TraktDevice device)
        {
            return await GetAccessTokenAsync(device, Client.ClientId, Client.ClientSecret);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(TraktDevice device, string clientId)
        {
            return await GetAccessTokenAsync(device, clientId, Client.ClientSecret);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(TraktDevice device, string clientId, string clientSecret)
        {
            ValidateAccessTokenInput(device, clientId, clientSecret);

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                SetDefaultRequestHeaders(httpClient);

                using (var content = new StringContent(postContent))
                {
                    HttpStatusCode responseCode = HttpStatusCode.OK;
                    string reasonPhrase = null;
                    int totalExpiredSeconds = 0;

                    while (totalExpiredSeconds < device.ExpiresInSeconds)
                    {
                        using (var response = await httpClient.PostAsync(TraktConstants.OAuthDeviceTokenUri, content))
                        {
                            responseCode = response.StatusCode;

                            if (responseCode == HttpStatusCode.OK) // Success
                            {
                                var data = await response.Content.ReadAsStringAsync();
                                var token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAccessToken>(data));

                                Client.Authentication.AccessToken = token;

                                return token;
                            }
                            else if (responseCode == HttpStatusCode.BadRequest) // Pending
                            {
                                await Task.Delay(device.IntervalInSeconds * 1000);
                                totalExpiredSeconds += device.IntervalInSeconds;
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    var requestUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceTokenUri}";

                    switch (responseCode)
                    {
                        case HttpStatusCode.NotFound:
                            throw new TraktAuthenticationDeviceException("Not Found - invalid device_code")
                            {
                                StatusCode = responseCode,
                                RequestUrl = requestUrl,
                                RequestBody = postContent,
                                ServerReasonPhrase = reasonPhrase
                            };
                        case HttpStatusCode.Conflict:   // Already Used
                            throw new TraktAuthenticationDeviceException("Already Used - user already approved this code")
                            {
                                StatusCode = responseCode,
                                RequestUrl = requestUrl,
                                RequestBody = postContent,
                                ServerReasonPhrase = reasonPhrase
                            };
                        case HttpStatusCode.Gone:       // Expired
                            throw new TraktAuthenticationDeviceException("Expired - the tokens have expired, restart the process")
                            {
                                StatusCode = responseCode,
                                RequestUrl = requestUrl,
                                RequestBody = postContent,
                                ServerReasonPhrase = reasonPhrase
                            };
                        case (HttpStatusCode)418:       // Denied
                            throw new TraktAuthenticationDeviceException("Denied - user explicitly denied this code")
                            {
                                StatusCode = (HttpStatusCode)418,
                                RequestUrl = requestUrl,
                                RequestBody = postContent,
                                ServerReasonPhrase = reasonPhrase
                            };
                        case (HttpStatusCode)429:       // Slow Down
                            throw new TraktAuthenticationDeviceException("Slow Down - your app is polling too quickly")
                            {
                                StatusCode = (HttpStatusCode)429,
                                RequestUrl = requestUrl,
                                RequestBody = postContent,
                                ServerReasonPhrase = reasonPhrase
                            };
                        default:
                            throw new TraktAuthenticationDeviceException("unknown exception") { ServerReasonPhrase = reasonPhrase };
                    }
                }
            }
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync()
        {
            return await Client.Authentication.RefreshAccessTokenAsync();
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            return await Client.Authentication.RefreshAccessTokenAsync(refreshToken, clientId, clientSecret, redirectUri);
        }

        public async Task<bool> RevokeAccessTokenAsync()
        {
            return await Client.Authentication.RevokeAccessTokenAsync();
        }

        public async Task<bool> RevokeAccessTokenAsync(string accessToken, string clientId)
        {
            return await Client.Authentication.RevokeAccessTokenAsync(accessToken, clientId);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void ValidateAccessTokenInput(TraktDevice device, string clientId, string clientSecret)
        {
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
    }
}
