namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;

    /// <summary>Provides access to OAuth authentication methods, such as creating a new authorization URL and getting a new access token.</summary>
    public class TraktOAuth
    {
        internal TraktOAuth(TraktClient client) { Client = client; }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="TraktAuthentication.ClientId" /> and
        /// <see cref="TraktAuthentication.RedirectUri" /> to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl()
        {
            var clientId = Client.ClientId;
            var redirectUri = Client.Authentication.RedirectUri;

            return CreateAuthorizationUrl(clientId, redirectUri);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="TraktAuthentication.RedirectUri" /> to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId)
        {
            var redirectUri = Client.Authentication.RedirectUri;
            return CreateAuthorizationUrl(clientId, redirectUri);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.RedirectUri" />.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId, string redirectUri)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri);
            return BuildAuthorizationUrl(clientId, redirectUri);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.RedirectUri" />.</param>
        /// <param name="state">
        /// The state variable, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.AntiForgeryToken" />.
        /// This parameter is optional and will not be used, if it's null or empty.
        /// </param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri, state);
            return BuildAuthorizationUrl(clientId, redirectUri, state);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="TraktAuthentication.ClientId" />,
        /// <see cref="TraktAuthentication.RedirectUri" /> and <see cref="TraktAuthentication.AntiForgeryToken" />
        /// as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState()
        {
            var clientId = Client.ClientId;
            var redirectUri = Client.Authentication.RedirectUri;
            var state = Client.Authentication.AntiForgeryToken;

            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="TraktAuthentication.RedirectUri" />
        /// and <see cref="TraktAuthentication.AntiForgeryToken" /> as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState(string clientId)
        {
            var redirectUri = Client.Authentication.RedirectUri;
            var state = Client.Authentication.AntiForgeryToken;
            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the <see cref="TraktAuthentication.AntiForgeryToken" /> as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL. See also <seealso cref="TraktAuthentication.RedirectUri" />.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri)
        {
            var state = Client.Authentication.AntiForgeryToken;
            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="TraktAuthentication.OAuthAuthorizationCode" /> for the request, which has to be set before a call to this method.
        /// Also uses the current <see cref="TraktAuthentication.ClientId" />, <see cref="TraktAuthentication.ClientSecret" /> and
        /// <see cref="TraktAuthentication.RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GetAuthorizationAsync(string)" />, <seealso cref="GetAuthorizationAsync(string, string)" />,
        /// <seealso cref="GetAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="GetAuthorizationAsync(string, string, string, string)" />.
        /// </para>
        /// </summary>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the current OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> GetAuthorizationAsync()
            => await GetAuthorizationAsync(Client.Authentication.OAuthAuthorizationCode);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current <see cref="TraktAuthentication.ClientId" />,
        /// <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GetAuthorizationAsync()" />, <seealso cref="GetAuthorizationAsync(string, string)" />,
        /// <seealso cref="GetAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="GetAuthorizationAsync(string, string, string, string)" />.
        /// </para>
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request. See also <seealso cref="TraktAuthentication.OAuthAuthorizationCode" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> GetAuthorizationAsync(string code)
            => await GetAuthorizationAsync(code, Client.ClientId, Client.ClientSecret, Client.Authentication.RedirectUri);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current <see cref="TraktAuthentication.ClientSecret" /> and
        /// <see cref="TraktAuthentication.RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GetAuthorizationAsync()" />, <seealso cref="GetAuthorizationAsync(string)" />,
        /// <seealso cref="GetAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="GetAuthorizationAsync(string, string, string, string)" />.
        /// </para>
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request. See also <seealso cref="TraktAuthentication.OAuthAuthorizationCode" />.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId)
            => await GetAuthorizationAsync(code, clientId, Client.ClientSecret, Client.Authentication.RedirectUri);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current see cref="TraktAuthentication.RedirectUri" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GetAuthorizationAsync()" />, <seealso cref="GetAuthorizationAsync(string)" />,
        /// <seealso cref="GetAuthorizationAsync(string, string)" /> and
        /// <seealso cref="GetAuthorizationAsync(string, string, string, string)" />.
        /// </para>
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request. See also <seealso cref="TraktAuthentication.OAuthAuthorizationCode" />.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientSecret" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId, string clientSecret)
            => await GetAuthorizationAsync(code, clientId, clientSecret, Client.Authentication.RedirectUri);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GetAuthorizationAsync()" />, <seealso cref="GetAuthorizationAsync(string)" />,
        /// <seealso cref="GetAuthorizationAsync(string, string)" /> and
        /// <seealso cref="GetAuthorizationAsync(string, string, string)" />.
        /// </para>
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request. See also <seealso cref="TraktAuthentication.OAuthAuthorizationCode" />.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientSecret" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request. See also <seealso cref="TraktAuthentication.RedirectUri" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the given redirect URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> GetAuthorizationAsync(string code, string clientId, string clientSecret, string redirectUri)
        {
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.ObjectName;

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

            var response = await httpClient.PostAsync(tokenUrl, content).ConfigureAwait(false);

            HttpStatusCode responseCode = response.StatusCode;
            string responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;
            string reasonPhrase = response.ReasonPhrase;

            if (responseCode == HttpStatusCode.OK)
            {
                var token = default(TraktAuthorization);

                if (!string.IsNullOrEmpty(responseContent))
                    token = Json.Deserialize<TraktAuthorization>(responseContent);

                Client.Authentication.Authorization = token;
                return token;
            }
            else if (responseCode == HttpStatusCode.Unauthorized) // Invalid code
            {
                var error = default(TraktError);

                if (!string.IsNullOrEmpty(responseContent))
                    error = Json.Deserialize<TraktError>(responseContent);

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

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktAuthentication.Authorization" />'s refresh token, <see cref="TraktAuthentication.ClientId" />,
        /// <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" />, 
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the current refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if the current refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the current refresh token is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty of contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current rediret URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> RefreshAuthorizationAsync()
            => await Client.Authentication.RefreshAuthorizationAsync();

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktAuthentication.ClientId" />, <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given refresh token is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty of contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current rediret URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken)
            => await Client.Authentication.RefreshAuthorizationAsync(refreshToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given refresh token is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty of contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current rediret URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId)
            => await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientSecret" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given refresh token is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty of contains spaces.
        /// Thrown, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the current rediret URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret)
            => await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientSecret" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request. See also <seealso cref="TraktAuthentication.RedirectUri" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given refresh token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if the given refresh token is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given refresh token is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty of contains spaces.
        /// Thrown, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the given rediret URI is null, empty or contains spaces.
        /// </exception>
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId,
                                                                        string clientSecret, string redirectUri)
            => await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, redirectUri);

        /// <summary>
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="TraktAuthentication.Authorization" />'s access token and <see cref="TraktAuthentication.ClientId" />.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync(string)" />, <seealso cref="RevokeAuthorizationAsync(string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the current access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if revoking the current access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the current access token is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// </exception>
        public async Task RevokeAuthorizationAsync()
        {
            await Client.Authentication.RevokeAuthorizationAsync();
        }

        /// <summary>
        /// Revokes the given access token. If, successful, the given access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="TraktAuthentication.ClientId" />.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync()" />, <seealso cref="RevokeAuthorizationAsync(string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked. See also <seealso cref="TraktAuthorization.AccessToken" />.</param>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given access token is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// </exception>
        public async Task RevokeAuthorizationAsync(string accessToken)
        {
            await Client.Authentication.RevokeAuthorizationAsync(accessToken);
        }

        /// <summary>
        /// Revokes the given access token. If, successful, the given access token will be invalid
        /// and the user has to be re-authenticated.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync()" />, <seealso cref="RevokeAuthorizationAsync(string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The access token, which will be revoked. See also <seealso cref="TraktAuthorization.AccessToken" />.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given access token is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// </exception>
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
            var isStagingUsed = Client.Configuration.UseStagingUrl;
            var baseUrl = isStagingUsed ? TraktConstants.OAuthBaseAuthorizeStagingUrl : TraktConstants.OAuthBaseAuthorizeUrl;
            var authorizationUrl = $"{baseUrl}/{TraktConstants.OAuthAuthorizeUri}{encodedUriParams}";
            return authorizationUrl;
        }

        private void ValidateAuthorizationUrlParameters(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(redirectUri));
        }

        private void ValidateAuthorizationUrlParameters(string clientId, string redirectUri, string state)
        {
            ValidateAuthorizationUrlParameters(clientId, redirectUri);

            if (string.IsNullOrEmpty(state) || state.ContainsSpace())
                throw new ArgumentException("state not valid", nameof(state));
        }

        private void ValidateAccessTokenInput(string code, string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(code) || code.ContainsSpace())
                throw new ArgumentException("code not valid", nameof(code));

            ValidateAuthorizationUrlParameters(clientId, redirectUri);

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(clientSecret));

            if (string.IsNullOrEmpty(grantType))
                throw new ArgumentException("grant type not valid", nameof(grantType));
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
