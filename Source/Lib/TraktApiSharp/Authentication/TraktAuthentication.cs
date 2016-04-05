namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class TraktAuthentication
    {
        private const TraktAuthenticationMode DEFAULT_AUTHENTICATION_MODE = TraktAuthenticationMode.Device;
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private TraktAccessToken _accessToken;
        private TraktDevice _device;

        internal TraktAuthentication(TraktClient client)
        {
            Client = client;
            AuthenticationMode = DEFAULT_AUTHENTICATION_MODE;
            AntiForgeryToken = Guid.NewGuid().ToString();
            RedirectUri = DEFAULT_REDIRECT_URI;
        }

        public TraktClient Client { get; private set; }

        public TraktAuthenticationMode AuthenticationMode { get; set; }

        public TraktAccessToken AccessToken
        {
            get { return _accessToken = _accessToken ?? new TraktAccessToken(); }
            set { _accessToken = value; }
        }

        public TraktDevice Device
        {
            get { return _device = _device ?? new TraktDevice(); }
            set { _device = value; }
        }

        public string AuthorizationCode { get; set; }

        public string AntiForgeryToken { get; private set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; }

        public bool IsAuthenticated
        {
            get { return AccessToken != null && AccessToken.IsValid; }
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync()
        {
            // TODO catch exceptions

            switch (AuthenticationMode)
            {
                case TraktAuthenticationMode.Device:
                    {
                        await Client.DeviceAuth.GenerateDeviceAsync();
                        return await Client.DeviceAuth.GetAccessTokenAsync();
                    }
                case TraktAuthenticationMode.OAuth:
                    {
                        if (await Client.OAuth.AuthorizeAsync())
                            return await Client.OAuth.GetAccessTokenAsync();

                        return null;
                    }
            }

            return null;
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync()
        {
            if (!IsAuthenticated)
                throw new ArgumentException("not authenticated");

            return await RefreshAccessTokenAsync(AccessToken.RefreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            validateRefreshTokenInput(refreshToken, clientId, clientSecret, redirectUri, grantType);

            var postContent = string.Format("{ \"refresh_token\": \"{0}\", \"client_id\": \"{1}\"," +
                                            " \"client_secret\": \"{2}\", \"redirect_uri\": \"{3}\"," +
                                            " \"grant_type\": \"{4}\" }",
                                            refreshToken, clientId, clientSecret, redirectUri, grantType);

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(postContent))
                using (var response = await httpClient.PostAsync(TraktConstants.OAuthTokenUri, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAccessToken>(data));

                        AccessToken = token;

                        return token;
                    }

                    // TODO use an appropiate exception
                    throw new Exception("response not valid");
                }
            }
        }

        public async Task<bool> RevokeAccessTokenAsync()
        {
            if (!IsAuthenticated)
                throw new ArgumentException("not authenticated", "IsAuthenticated");  // TODO create authentication exception

            return await RevokeAccessTokenAsync(AccessToken.AccessToken, Client.ClientId);
        }

        public async Task<bool> RevokeAccessTokenAsync(string accessToken, string clientId)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentException("access token not valid", "accessToken");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            var postContent = string.Format("{ \"access_token\": \"{0}\" }", accessToken);

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Add("authorization", string.Format("Bearer {0}", accessToken));
                httpClient.DefaultRequestHeaders.Add("trakt-api-version", string.Format("{0}", Client.Configuration.ApiVersion));
                httpClient.DefaultRequestHeaders.Add("trakt-api-key", clientId);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(postContent))
                using (var response = await httpClient.PostAsync(TraktConstants.OAuthRevokeUri, content))
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
        }

        private void validateRefreshTokenInput(string refreshToken, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentException("refresh token is not valid", "refreshToken");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("client secret not valid", "clientSecret");

            if (string.IsNullOrEmpty(redirectUri))
                throw new ArgumentException("redirect uri is not valid", "redirectUri");

            if (string.IsNullOrEmpty(grantType))
                throw new ArgumentException("grant type is not valid", "grantType");
        }
    }
}
