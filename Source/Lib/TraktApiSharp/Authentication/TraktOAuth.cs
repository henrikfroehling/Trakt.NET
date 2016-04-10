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

    public class TraktOAuth
    {
        internal TraktOAuth(TraktClient client)
        {
            Client = client;
        }

        public TraktClient Client { get; private set; }

        public async Task<bool> AuthorizeAsync()
        {
            return await AuthorizeAsync(Client.ClientId, Client.Authentication.RedirectUri, Client.Authentication.AntiForgeryToken);
        }

        public async Task<bool> AuthorizeAsync(string clientId, string redirectUri, string state)
        {
            validateAuthorizationInput(clientId, redirectUri, state);

            var baseUri = new Uri(TraktConstants.OAuthBaseAuthorizeUrl);

            var authorizationUri = string.Format("{0}?response_type=code&client_id={1}&redirect_uri={2}&state={3}",
                                                 TraktConstants.OAuthAuthorizeUri, clientId, Uri.EscapeDataString(redirectUri), state);

            using (var httpClient = new HttpClient { BaseAddress = baseUri })
            {
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await httpClient.GetAsync(authorizationUri))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // TODO parse uri response parameter for authorization code
                        Client.Authentication.AuthorizationCode = await response.Content.ReadAsStringAsync();
                        return true;
                    }

                    return false;
                }
            }
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync()
        {
            return await GetAccessTokenAsync(Client.Authentication.AuthorizationCode, Client.ClientId, Client.ClientSecret, Client.Authentication.RedirectUri);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(string code, string clientId, string clientSecret, string redirectUri)
        {
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            validateAccessTokenInput(code, clientId, clientSecret, redirectUri, grantType);

            var postContent = string.Format(@"{{ ""code"": ""{0}"", ""client_id"": ""{1}"", ""client_secret"": ""{2}"", ""redirect_uri"": ""{3}"", ""grant_type"": ""{4}"" }}",
                                            code, clientId, clientSecret, redirectUri, grantType);

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(postContent))
                using (var response = await httpClient.PostAsync(TraktConstants.OAuthTokenUri, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var token = await Task.Run(() => JsonConvert.DeserializeObject<TraktAccessToken>(data));

                        Client.Authentication.AccessToken = token;

                        return token;
                    }

                    // TODO use an appropiate exception
                    throw new Exception("response not valid");
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

        private void validateAuthorizationInput(string clientId, string redirectUri, string state)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(redirectUri))
                throw new ArgumentException("redirect uri is not valid", "redirectUri");

            if (string.IsNullOrEmpty(state))
                throw new ArgumentException("state is not valid", "state");
        }

        private void validateAccessTokenInput(string code, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("code is not valid", "code");

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
