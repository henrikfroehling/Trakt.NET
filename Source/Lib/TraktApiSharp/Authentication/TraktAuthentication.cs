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
    using System.Threading.Tasks;

    public class TraktAuthentication
    {
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private TraktAccessToken _accessToken;
        private TraktDevice _device;

        internal TraktAuthentication(TraktClient client)
        {
            Client = client;
            AntiForgeryToken = Guid.NewGuid().ToString();
            RedirectUri = DEFAULT_REDIRECT_URI;
        }

        public TraktClient Client { get; private set; }

        public string OAuthAuthorizationCode { get; set; }

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

        public string AntiForgeryToken { get; private set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; }

        public bool IsAuthenticated => AccessToken != null && AccessToken.IsValid;

        public async Task<TraktAccessToken> RefreshAccessTokenAsync()
        {
            return await RefreshAccessTokenAsync(AccessToken.RefreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken)
        {
            return await RefreshAccessTokenAsync(refreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId)
        {
            return await RefreshAccessTokenAsync(refreshToken, clientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret)
        {
            return await RefreshAccessTokenAsync(refreshToken, clientId, Client.ClientSecret, RedirectUri);
        }

        public async Task<TraktAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            if (!IsAuthenticated)
                throw new TraktAuthenticationException("not authenticated");

            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            ValidateRefreshTokenInput(refreshToken, clientId, clientSecret, redirectUri, grantType);

            var postContent = $"{{ \"refresh_token\": \"{refreshToken}\", \"client_id\": \"{clientId}\"," +
                              $" \"client_secret\": \"{clientSecret}\", \"redirect_uri\": \"{redirectUri}\"," +
                              $" \"grant_type\": \"{grantType}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
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

                    if (response.StatusCode == HttpStatusCode.Unauthorized) // Invalid refresh_token
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var error = await Task.Run(() => JsonConvert.DeserializeObject<TraktError>(data));

                        var errorMessage = $"error on refreshing access token\nerror: {error.Error}\ndescription: {error.Description}";

                        throw new TraktAuthenticationException(errorMessage)
                        {
                            StatusCode = response.StatusCode,
                            RequestUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthTokenUri}",
                            RequestBody = postContent,
                            ServerReasonPhrase = response.ReasonPhrase
                        };
                    }

                    throw new TraktAuthenticationException("unknown exception");
                }
            }
        }

        public async Task<bool> RevokeAccessTokenAsync()
        {
            return await RevokeAccessTokenAsync(AccessToken.AccessToken, Client.ClientId);
        }

        public async Task<bool> RevokeAccessTokenAsync(string accessToken)
        {
            return await RevokeAccessTokenAsync(accessToken, Client.ClientId);
        }

        public async Task<bool> RevokeAccessTokenAsync(string accessToken, string clientId)
        {
            if (!IsAuthenticated)
                throw new TraktAuthenticationException("not authenticated");

            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentException("access token not valid", "accessToken");

            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id not valid", "clientId");

            var postContent = $"{{ \"access_token\": \"{accessToken}\" }}";

            using (var httpClient = new HttpClient { BaseAddress = Client.Configuration.BaseUri })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.DefaultRequestHeaders.Add("trakt-api-key", Client.ClientId);
                httpClient.DefaultRequestHeaders.Add("trakt-api-version", $"{Client.Configuration.ApiVersion}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using (var content = new StringContent(postContent))
                using (var response = await httpClient.PostAsync(TraktConstants.OAuthRevokeUri, content))
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
        }

        private void ValidateRefreshTokenInput(string refreshToken, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(refreshToken) || refreshToken.ContainsSpace())
                throw new ArgumentException("refresh token not valid", "refreshToken");

            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", "clientId");

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", "clientSecret");

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", "redirectUri");

            if (string.IsNullOrEmpty(grantType))
                throw new ArgumentException("grant type not valid", "grantType");
        }
    }
}
