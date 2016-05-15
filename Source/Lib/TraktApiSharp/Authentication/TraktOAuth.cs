namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Exceptions;
    using Newtonsoft.Json;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;
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
            return await AuthorizeAsync(Client.ClientId, Client.Authentication.RedirectUri);
        }

        public async Task<bool> AuthorizeWithStateAsync()
        {
            return await AuthorizeWithStateAsync(Client.ClientId, Client.Authentication.RedirectUri, Client.Authentication.AntiForgeryToken);
        }

        public async Task<bool> AuthorizeAsync(string clientId, string redirectUri)
        {
            return await AuthorizeWithStateAsync(clientId, redirectUri);
        }

        public async Task<bool> AuthorizeWithStateAsync(string clientId, string redirectUri, string state = null)
        {
            validateAuthorizationWithStateInput(clientId, redirectUri, state);

            var baseUri = new Uri(TraktConstants.OAuthBaseAuthorizeUrl);
            var encodedUriParams = CreateEncodedAuthorizationUri(clientId, redirectUri, state);
            var authorizationUri = $"{TraktConstants.OAuthAuthorizeUri}{encodedUriParams}";

            using (var httpClient = new HttpClient { BaseAddress = baseUri })
            {
                SetDefaultRequestHeaders(httpClient);

                using (var response = await httpClient.GetAsync(authorizationUri))
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(string code)
        {
            return await GetAccessTokenAsync(code, Client.ClientId, Client.ClientSecret, Client.Authentication.RedirectUri);
        }

        public async Task<TraktAccessToken> GetAccessTokenAsync(string code, string clientId, string clientSecret, string redirectUri)
        {
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            validateAccessTokenInput(code, clientId, clientSecret, redirectUri, grantType);

            var postContent = $"{{ \"code\": \"{code}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\", " +
                              $"\"redirect_uri\": \"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                SetDefaultRequestHeaders(httpClient);

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

                    if (response.StatusCode == HttpStatusCode.Unauthorized) // Invalid code
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var error = await Task.Run(() => JsonConvert.DeserializeObject<TraktError>(data));

                        var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\ndescription: {error.Description}";

                        throw new TraktAuthenticationOAuthException(errorMessage)
                        {
                            StatusCode = response.StatusCode,
                            RequestUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthTokenUri}",
                            RequestBody = postContent
                        };
                    }

                    throw new TraktAuthenticationOAuthException("unknown exception");
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

        private void validateAuthorizationInput(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(redirectUri))
                throw new ArgumentException("redirect uri not valid", "redirectUri");
        }

        private void validateAuthorizationWithStateInput(string clientId, string redirectUri, string state)
        {
            validateAuthorizationInput(clientId, redirectUri);

            if (string.IsNullOrEmpty(state))
                throw new ArgumentException("state not valid", "state");
        }

        private void validateAccessTokenInput(string code, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("code not valid", "code");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("client secret not valid", "clientSecret");

            if (string.IsNullOrEmpty(redirectUri))
                throw new ArgumentException("redirect uri not valid", "redirectUri");

            if (string.IsNullOrEmpty(grantType))
                throw new ArgumentException("grant type not valid", "grantType");

        }
    }
}
