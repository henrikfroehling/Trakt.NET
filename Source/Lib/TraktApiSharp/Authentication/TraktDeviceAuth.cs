namespace TraktApiSharp.Authentication
{
    using Core;
    using Exceptions;
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
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                SetDefaultRequestHeaders(httpClient);

                using (var content = new StringContent(postContent))
                using (var response = await httpClient.PostAsync(TraktConstants.OAuthDeviceCodeUri, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var device = await Task.Run(() => JsonConvert.DeserializeObject<TraktDevice>(data));

                        Client.Authentication.Device = device;

                        return device;
                    }
                    else
                    {
                        throw new TraktAuthenticationDeviceException("error on generating authentication device")
                        {
                            StatusCode = response.StatusCode,
                            RequestUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceCodeUri}",
                            RequestBody = postContent,
                            Response = await response.Content.ReadAsStringAsync()
                        };
                    }
                }
            }
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync()
        {
            return await GetAccessTokenAsync(Client.Authentication.Device, Client.ClientId, Client.ClientSecret);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(TraktDevice device, string clientId, string clientSecret)
        {
            validateAccessTokenInput(device, clientId, clientSecret);

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                SetDefaultRequestHeaders(httpClient);

                using (var content = new StringContent(postContent))
                {
                    HttpStatusCode responseCode = HttpStatusCode.OK;
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
                            { StatusCode = responseCode, RequestUrl = requestUrl, RequestBody = postContent };
                        case HttpStatusCode.Conflict:   // Already Used
                            throw new TraktAuthenticationDeviceException("Already Used - user already approved this code")
                            { StatusCode = responseCode, RequestUrl = requestUrl, RequestBody = postContent };
                        case HttpStatusCode.Gone:       // Expired
                            throw new TraktAuthenticationDeviceException("Expired - the tokens have expired, restart the process")
                            { StatusCode = responseCode, RequestUrl = requestUrl, RequestBody = postContent };
                        case (HttpStatusCode)418:       // Denied
                            throw new TraktAuthenticationDeviceException("Denied - user explicitly denied this code")
                            { StatusCode = (HttpStatusCode)418, RequestUrl = requestUrl, RequestBody = postContent };
                        case (HttpStatusCode)429:       // Slow Down
                            throw new TraktAuthenticationDeviceException("Slow Down - your app is polling too quickly")
                            { StatusCode = (HttpStatusCode)429, RequestUrl = requestUrl, RequestBody = postContent };
                        default:
                            throw new TraktAuthenticationDeviceException("unknown exception");
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
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void validateAccessTokenInput(TraktDevice device, string clientId, string clientSecret)
        {
            if (device.IsExpiredUnused)
                throw new ArgumentException("device code expired unused", "device");

            if (!device.IsValid)
                throw new ArgumentException("device not valid", "device");

            if (string.IsNullOrEmpty(device.DeviceCode))
                throw new ArgumentException("device code not valid", "device");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("client secret not valid", "clientSecret");
        }
    }
}
