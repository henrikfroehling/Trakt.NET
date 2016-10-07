namespace TraktApiSharp.Authentication
{
    using Core;
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Basic;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;

    /// <summary>
    /// Provides access to authentication methods common to both OAuth and Device authentication,
    /// such as refreshing and revoking the current access token.<para />
    /// Besides, contains current authorization state information.
    /// </summary>
    public class TraktAuthentication
    {
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private TraktAuthorization _authorization;
        private TraktDevice _device;

        internal TraktAuthentication(TraktClient client) { Client = client; }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        /// <summary>
        /// Gets or sets the OAuth authorization code.
        /// <para>
        /// See also <seealso cref="TraktOAuth.GetAuthorizationAsync()" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string)" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string)" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string, string)" />.
        /// </para>
        /// </summary>
        public string OAuthAuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TraktAuthorization" /> information.
        /// <para>
        /// Will also be set by <seealso cref="TraktOAuth.GetAuthorizationAsync()" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string) "/>, <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string)" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string)" />,
        /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string, string)" />,
        /// <seealso cref="RefreshAuthorizationAsync() "/>, <seealso cref="RefreshAuthorizationAsync(string) "/>,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" />, <seealso cref="RefreshAuthorizationAsync(string, string, string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />,
        /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync()" />, <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice)" />,
        /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice, string)" /> and
        /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice, string, string)" />.
        /// </para>
        /// </summary>
        public TraktAuthorization Authorization
        {
            get { return _authorization = _authorization ?? new TraktAuthorization(); }
            set { _authorization = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="TraktDevice" /> for Device authentication.
        /// <para>
        /// Will also be set by <seealso cref="TraktDeviceAuth.GenerateDeviceAsync()" /> and
        /// <seealso cref="TraktDeviceAuth.GenerateDeviceAsync(string)" />.
        /// </para>
        /// </summary>
        public TraktDevice Device
        {
            get { return _device = _device ?? new TraktDevice(); }
            set { _device = value; }
        }

        /// <summary>
        /// Gets a GUID, which can be used for OAuth authentication requests.
        /// <para>
        /// See also <seealso cref="TraktOAuth.CreateAuthorizationUrl(string, string, string)" />,
        /// <seealso cref="TraktOAuth.CreateAuthorizationUrlWithDefaultState()" />,
        /// <seealso cref="TraktOAuth.CreateAuthorizationUrlWithDefaultState(string)" /> and
        /// <seealso cref="TraktOAuth.CreateAuthorizationUrlWithDefaultState(string, string)" />.
        /// </para>
        /// </summary>
        public string AntiForgeryToken { get; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the Trakt Client Id. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientId { get; set; }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientId" />.</summary>
        public string ClientSecret { get; set; }

        /// <summary>Gets or sets the Trakt redirect URI for OAuth authentication.</summary>
        public string RedirectUri { get; set; } = DEFAULT_REDIRECT_URI;

        /// <summary>
        /// Returns whether the client is authorized with a valid access token.
        /// See also <seealso cref="TraktAuthorization.IsExpired" />.
        /// </summary>
        public bool IsAuthorized => Authorization != null && !Authorization.IsExpired;

        /// <summary>
        /// Calls <see cref="Modules.TraktSyncModule.GetLastActivitiesAsync()" /> to check,
        /// whether the current <see cref="Authorization" /> is not expired yet and was not revoked by the user.
        /// </summary>
        /// <param name="autoRefresh">
        /// Indicates, whether the current <see cref="Authorization" /> should be refreshed, if it was revoked.
        /// If this is set to true, <see cref="RefreshAuthorizationAsync()" /> will be called.<para /> 
        /// See also <seealso cref="RefreshAuthorizationAsync()" />.
        /// </param>
        /// <returns>
        /// Returns an <see cref="Pair{T, U}" /> instance with <see cref="Pair{T, U}.First" /> set to true,
        /// if the current <see cref="Authorization" /> is expired or was revoked, otherwise set to false.
        /// If <paramref name="autoRefresh" /> is set to true, the returned <see cref="Pair{T, U}.Second" /> contains the new
        /// <see cref="TraktAuthorization" /> information, otherwise the returned <see cref="Pair{T, U}.Second" /> will be null.
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request <see cref="RefreshAuthorizationAsync()" /> fails.</exception>
        public async Task<Pair<bool, TraktAuthorization>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(bool autoRefresh = false)
        {
            if (Authorization.IsExpired)
                return new Pair<bool, TraktAuthorization>(true, null);

            try
            {
                await Client.Sync.GetLastActivitiesAsync();
                return new Pair<bool, TraktAuthorization>(false, null);
            }
            catch (TraktAuthorizationException)
            {
                if (!autoRefresh)
                    return new Pair<bool, TraktAuthorization>(true, null);

                var newAuthorization = await RefreshAuthorizationAsync();
                return new Pair<bool, TraktAuthorization>(true, newAuthorization);
            }
        }

        /// <summary>
        /// Calls <see cref="Modules.TraktSyncModule.GetLastActivitiesAsync()" /> to check,
        /// whether the given <see cref="TraktAuthorization" /> is not expired yet and was not revoked by the user.
        /// </summary>
        /// <param name="authorization">The authorization information, which will be checked.</param>
        /// <param name="autoRefresh">
        /// Indicates, whether the current <see cref="Authorization" /> should be refreshed, if it was revoked.
        /// If this is set to true, <see cref="RefreshAuthorizationAsync()" /> will be called.<para /> 
        /// See also <seealso cref="RefreshAuthorizationAsync()" />.
        /// </param>
        /// <returns>
        /// Returns an <see cref="Pair{T, U}" /> instance with <see cref="Pair{T, U}.First" /> set to true,
        /// if the current <see cref="Authorization" /> is expired or was revoked, otherwise set to false.
        /// If <paramref name="autoRefresh" /> is set to true, the returned <see cref="Pair{T, U}.Second" /> contains the new
        /// <see cref="TraktAuthorization" /> information, otherwise the returned <see cref="Pair{T, U}.Second" /> will be null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="authorization" /> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request <see cref="RefreshAuthorizationAsync()" /> fails.</exception>
        public async Task<Pair<bool, TraktAuthorization>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(TraktAuthorization authorization, bool autoRefresh = false)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization));

            var currentAuthorization = Authorization;
            Authorization = authorization;

            var result = new Pair<bool, TraktAuthorization>(true, null);

            try
            {
                result = await CheckIfAuthorizationIsExpiredOrWasRevokedAsync(autoRefresh);
            }
            finally
            {
                Authorization = currentAuthorization;
            }

            return result;
        }

        /// <summary>
        /// Calls <see cref="Modules.TraktSyncModule.GetLastActivitiesAsync()" /> to check,
        /// whether the given access token is still valid and was not revoked by the user.
        /// </summary>
        /// <param name="accessToken">The access token, which will be checked.</param>
        /// <returns>True, if the given access token was revoked and / or is not valid anymore, otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given access token is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request <see cref="Modules.TraktSyncModule.GetLastActivitiesAsync()" /> fails.</exception>
        public async Task<bool> CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace())
                throw new ArgumentException("access token must not be null, empty or contain any spaces", nameof(accessToken));

            var currentAuthorization = Authorization;
            Authorization = TraktAuthorization.CreateWith(accessToken);

            try
            {
                await Client.Sync.GetLastActivitiesAsync();
                return false;
            }
            catch (TraktAuthorizationException)
            {
                return true;
            }
            finally
            {
                Authorization = currentAuthorization;
            }
        }

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="Authorization" />'s refresh token, <see cref="ClientId" />,
        /// <see cref="ClientSecret" /> and <see cref="RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" />, 
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="Authorization" />.
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
            => await RefreshAuthorizationAsync(Authorization.RefreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="ClientId" />, <see cref="ClientSecret" /> and <see cref="RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="Authorization" />.
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
            => await RefreshAuthorizationAsync(refreshToken, Client.ClientId, Client.ClientSecret, RedirectUri);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="ClientSecret" /> and <see cref="RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="ClientId" />.</param>
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
            => await RefreshAuthorizationAsync(refreshToken, clientId, Client.ClientSecret, RedirectUri);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="ClientSecret" /> and <see cref="RedirectUri" />for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string, string)" />.
        /// See also <seealso cref="Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="ClientSecret" />.</param>
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
            => await RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, RedirectUri);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RefreshAuthorizationAsync()" />,
        /// <seealso cref="RefreshAuthorizationAsync(string)" />,
        /// <seealso cref="RefreshAuthorizationAsync(string, string)" /> and
        /// <seealso cref="RefreshAuthorizationAsync(string, string, string)" />.
        /// See also <seealso cref="Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="ClientSecret" />.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request. See also <seealso cref="RedirectUri" />.</param>
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
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            if (!IsAuthorized && (string.IsNullOrEmpty(refreshToken) || refreshToken.ContainsSpace()))
                throw new TraktAuthorizationException("not authorized");

            if (string.IsNullOrEmpty(refreshToken) || refreshToken.ContainsSpace())
                throw new ArgumentException("refresh token not valid", nameof(refreshToken));

            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            ValidateRefreshTokenInput(clientId, clientSecret, redirectUri, grantType);

            var postContent = $"{{ \"refresh_token\": \"{refreshToken}\", \"client_id\": \"{clientId}\"," +
                              $" \"client_secret\": \"{clientSecret}\", \"redirect_uri\": \"{redirectUri}\"," +
                              $" \"grant_type\": \"{grantType}\" }}";

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

                var errorMessage = error != null ? ($"error on refreshing oauth access token\nerror: {error.Error}\n" +
                                                    $"description: {error.Description}")
                                                 : "unknown error";

                throw new TraktAuthenticationException(errorMessage)
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
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated, e.g. by calling <see cref="TraktOAuth.GetAuthorizationAsync() "/>.
        /// Uses the current <see cref="Authorization" />'s access token and <see cref="ClientId" />.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync(string)" />, <seealso cref="RevokeAuthorizationAsync(string, string)" />.
        /// See also <seealso cref="Authorization" />.
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
            await RevokeAuthorizationAsync(Authorization.AccessToken, Client.ClientId);
        }

        /// <summary>
        /// Revokes the given access token. If, successful, the given access token will be invalid
        /// and the user has to be re-authenticated, e.g. by calling <see cref="TraktOAuth.GetAuthorizationAsync() "/>.
        /// Uses the current <see cref="ClientId" />.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync()" />, <seealso cref="RevokeAuthorizationAsync(string, string)" />.
        /// See also <seealso cref="Authorization" />.
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
            await RevokeAuthorizationAsync(accessToken, Client.ClientId);
        }

        /// <summary>
        /// Revokes the given access token. If, successful, the given access token will be invalid
        /// and the user has to be re-authenticated, e.g. by calling <see cref="TraktOAuth.GetAuthorizationAsync() "/>.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="RevokeAuthorizationAsync()" />, <seealso cref="RevokeAuthorizationAsync(string)" />.
        /// See also <seealso cref="Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The access token, which will be revoked. See also <seealso cref="TraktAuthorization.AccessToken" />.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="ClientId" />.</param>
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
            if (!IsAuthorized && (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace()))
                throw new TraktAuthorizationException("not authorized");

            if (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace())
                throw new ArgumentException("access token not valid", nameof(accessToken));

            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            var postContent = $"token={accessToken}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);
            SetAuthorizationRequestHeaders(httpClient, accessToken, clientId);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthRevokeUri}";
            var content = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync(tokenUrl, content).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

                    throw new TraktAuthenticationException("error on revoking access token")
                    {
                        RequestUrl = tokenUrl,
                        RequestBody = postContent,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                }

                await ErrorHandling(response, tokenUrl, postContent);
            }
            else
            {
                Client.Authorization = TraktAuthorization.CreateWith(string.Empty, string.Empty);
            }
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void SetAuthorizationRequestHeaders(HttpClient httpClient, string accessToken, string clientId)
        {
            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, clientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{Client.Configuration.ApiVersion}");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private void ValidateRefreshTokenInput(string clientId, string clientSecret, string redirectUri, string grantType)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(clientSecret));

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(redirectUri));

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

            throw new TraktAuthenticationException("unknown exception") { ServerReasonPhrase = reasonPhrase };
        }
    }
}
