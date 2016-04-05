namespace TraktApiSharp.Authentication
{
    using Core;
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

            var postContent = string.Format("{ \"client_id\": \"{0}\" }", clientId);

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
                        throw new Exception(""); // TODO create exception
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

            var postContent = string.Format("{ \"code\": \"{0}\", \"client_id\": \"{1}\", \"client_secret\": \"{2}\" }",
                                            device.DeviceCode, clientId, clientSecret);

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(postContent))
                {
                    int totalExpiredSeconds = 0;

                    while (totalExpiredSeconds < device.ExpiresInSeconds)
                    {
                        using (var response = await httpClient.PostAsync(TraktConstants.OAuthDeviceTokenUri, content))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var data = await response.Content.ReadAsStringAsync();
                                var token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAccessToken>(data));

                                Client.Authentication.AccessToken = token;

                                return token;
                            }
                            else if (response.StatusCode == HttpStatusCode.BadRequest)
                            {
                                await Task.Delay(device.Interval * 1000);
                                totalExpiredSeconds += device.Interval;
                                continue;
                            }
                            else
                            {
                                // TODO use an appropiate exception
                                throw new Exception("response not valid");
                            }
                        }
                    }

                    // TODO use an appropiate exception
                    throw new Exception("expired seconds");
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

        private void validateAccessTokenInput(TraktDevice device, string clientId, string clientSecret)
        {
            if (device.IsExpiredUnused)
                throw new ArgumentException("device code is expired unused", "device.IsExpiredUnused");

            if (!device.IsValid)
                throw new ArgumentException("device is not valid", "device.IsValid");

            if (string.IsNullOrEmpty(device.DeviceCode))
                throw new ArgumentException("device code not valid", "device.DeviceCode");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("client secret is not valid", "clientSecret");
        }
    }
}
