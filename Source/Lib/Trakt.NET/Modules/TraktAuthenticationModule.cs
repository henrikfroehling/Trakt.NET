namespace TraktNet.Modules
{
    using Core;
    using Exceptions;
    using Objects.Authentication;
    using Requests.Authentication;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/authentication-oauth">"Trakt API Doc - Authentication - OAuth"</a> section
    /// and the <a href="https://trakt.docs.apiary.io/#reference/authentication-devices">"Trakt API Doc - Authentication - Devices"</a> section.
    /// </para>
    /// </summary>
    public class TraktAuthenticationModule : ATraktModule
    {
        private ITraktAuthorization _authorization;
        private ITraktDevice _device;

        internal TraktAuthenticationModule(TraktClient client) : base(client)
        {
        }

        /// <summary>Gets or sets the OAuth authorization code.</summary>
        public string OAuthAuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITraktAuthorization" /> information.
        /// <para>
        /// Will also be set by <see cref="GetAuthorizationAsync(CancellationToken)" />,
        /// <see cref="GetAuthorizationAsync(string, CancellationToken) "/>, <see cref="GetAuthorizationAsync(string, string, CancellationToken)" />,
        /// <see cref="GetAuthorizationAsync(string, string, string, CancellationToken)" />,
        /// <see cref="GetAuthorizationAsync(string, string, string, string, CancellationToken)" />.
        /// </para>
        /// </summary>
        public ITraktAuthorization Authorization
        {
            get { return _authorization = _authorization ?? new TraktAuthorization(); }
            set { _authorization = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="ITraktDevice" /> for Device authentication.
        /// <para>
        /// Will also be set by <see cref="GenerateDeviceAsync(CancellationToken)" /> and
        /// <see cref="GenerateDeviceAsync(string, CancellationToken)" />.
        /// </para>
        /// </summary>
        public ITraktDevice Device
        {
            get { return _device = _device ?? new TraktDevice(); }
            set { _device = value; }
        }

        /// <summary>Gets a GUID, which can be used for OAuth authentication requests.</summary>
        public string AntiForgeryToken { get; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the Trakt Client Id.</summary>
        public string ClientId { get; set; }

        /// <summary>Gets or sets the Trakt Client Secret.</summary>
        public string ClientSecret { get; set; }

        /// <summary>Gets or sets the Trakt redirect URI for OAuth authentication.</summary>
        public string RedirectUri { get; set; } = Constants.DEFAULT_REDIRECT_URI;

        /// <summary>Returns whether the client is authorized with a valid access token.</summary>
        /// <seealso cref="ITraktAuthorization.IsExpired" />
        public bool IsAuthorized => Authorization?.IsExpired == false;

        /// <summary>
        /// Calls <see cref="TraktSyncModule.GetLastActivitiesAsync(CancellationToken)" /> to check,
        /// whether the current <see cref="Authorization" /> is not expired yet and was not revoked by the user.
        /// </summary>
        /// <param name="autoRefresh">
        /// Indicates, whether the current <see cref="Authorization" /> should be refreshed, if it was revoked.
        /// If this is set to true, <see cref="RefreshAuthorizationAsync(CancellationToken)" /> will be called.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// Returns an <see cref="Pair{T, U}" /> instance with <see cref="Pair{T, U}.First" /> set to true,
        /// if the current <see cref="Authorization" /> is expired or was revoked, otherwise set to false.
        /// If <paramref name="autoRefresh" /> is set to true, the returned <see cref="Pair{T, U}.Second" /> contains the new
        /// <see cref="ITraktAuthorization" /> information, otherwise the returned <see cref="Pair{T, U}.Second" /> will be null.
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request <see cref="RefreshAuthorizationAsync(CancellationToken)" /> fails.</exception>
        public Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(autoRefresh, cancellationToken);
        }

        /// <summary>
        /// Calls <see cref="TraktSyncModule.GetLastActivitiesAsync(CancellationToken)" /> to check,
        /// whether the given <paramref name="authorization"/> is not expired yet and was not revoked by the user.
        /// </summary>
        /// <param name="authorization">The authorization information, which will be checked.</param>
        /// <param name="autoRefresh">
        /// Indicates, whether the given <paramref name="authorization"/> should be refreshed, if it was revoked.
        /// If this is set to true, <see cref="RefreshAuthorizationAsync(CancellationToken)" /> will be called.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// Returns an <see cref="Pair{T, U}" /> instance with <see cref="Pair{T, U}.First" /> set to true,
        /// if the current <see cref="Authorization" /> is expired or was revoked, otherwise set to false.
        /// If <paramref name="autoRefresh" /> is set to true, the returned <see cref="Pair{T, U}.Second" /> contains the new
        /// <see cref="ITraktAuthorization" /> information, otherwise the returned <see cref="Pair{T, U}.Second" /> will be null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="authorization" /> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request <see cref="RefreshAuthorizationAsync(CancellationToken)" /> fails.</exception>
        public Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(ITraktAuthorization authorization, bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization, autoRefresh, cancellationToken);
        }

        /// <summary>
        /// Calls <see cref="TraktSyncModule.GetLastActivitiesAsync(CancellationToken)" /> to check,
        /// whether the given access token is still valid and was not revoked by the user.
        /// </summary>
        /// <param name="accessToken">The access token, which will be checked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>True, if the given access token was revoked and / or is not valid anymore, otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given access token is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request <see cref="TraktSyncModule.GetLastActivitiesAsync(CancellationToken)" /> fails.</exception>
        public Task<bool> CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken, cancellationToken);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="ClientId" /> and <see cref="RedirectUri" /> to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrl(ClientId, showSignupPage, forceLoginPrompt);

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="RedirectUri" /> to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrl(clientId, RedirectUri, showSignupPage, forceLoginPrompt);

        /// <summary>
        /// Creates a new OAuth authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId, string redirectUri, bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrl(clientId, redirectUri, null, showSignupPage, forceLoginPrompt);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="state">
        /// The state variable, which will be used to build the authorization URL. See also <see cref="AntiForgeryToken" />.
        /// This parameter is optional and will not be used, if it's null or empty.
        /// </param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state,
                                             bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrl(clientId, redirectUri, state, showSignupPage, forceLoginPrompt);
        }

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="ClientId" />, <see cref="RedirectUri" />
        /// and <see cref="AntiForgeryToken" /> as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState(bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlWithDefaultState(ClientId, showSignupPage, forceLoginPrompt);

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the current <see cref="RedirectUri" />
        /// and <see cref="AntiForgeryToken" /> as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState(string clientId, bool? showSignupPage = null, bool? forceLoginPrompt = null)
            => CreateAuthorizationUrlWithDefaultState(clientId, RedirectUri, showSignupPage, forceLoginPrompt);

        /// <summary>
        /// Creates a new OAuth authorization URL. Uses the <see cref="AntiForgeryToken" /> as state variable to build the authorization URL.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/authorize-application">"Trakt API Doc - OAuth: Authorize"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used to build the authorization URL.</param>
        /// <param name="redirectUri">The redirect URI, which will be used to build the authorization URL.</param>
        /// <param name="showSignupPage">Prefer the account sign up page to be the default.</param>
        /// <param name="forceLoginPrompt">Force the user to sign in and authorize your app.</param>
        /// <returns>Returns the created authorization URL.</returns>
        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri,
                                                             bool? showSignupPage = null, bool? forceLoginPrompt = null)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri, showSignupPage, forceLoginPrompt);
        }

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="OAuthAuthorizationCode" /> for the request, which has to be set before a call to this method.
        /// Also uses the current <see cref="ClientId" />, <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the current OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(OAuthAuthorizationCode, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="ClientId" />, <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, ClientId, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the current client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, ClientSecret, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token. Uses the current
        /// <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the current redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, clientSecret, RedirectUri, cancellationToken);

        /// <summary>
        /// Exchanges the OAuth authorization code from the user for a new access token.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// </summary>
        /// <param name="code">The OAuth authorization code, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationOAuthException">Thrown, if the OAuth authorization code is invalid.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given OAuth authorization code is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thronw, if the given client secret is null, empty or contains spaces.
        /// Thrown, if the given redirect URI is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRequest
            {
                RequestBody = new AuthorizationRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Code = code,
                    RedirectUri = redirectUri
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.GetAuthorizationAsync(request, cancellationToken);
        }

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process. Uses the current <see cref="ClientId" /> for the request.
        /// Assigns the returned <see cref="ITraktDevice" /> instance to <see cref="Device" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">"Trakt API Doc - Devices: Device Code"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktDevice" /> instance, which contains a new device code, user code and a verification URL.</returns>
        /// <exception cref="ArgumentException">Thrown, if the current client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<ITraktDevice>> GenerateDeviceAsync(CancellationToken cancellationToken = default)
            => GenerateDeviceAsync(ClientId, cancellationToken);

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process.
        /// Assigns the returned <see cref="ITraktDevice" /> instance to <see cref="Device" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">"Trakt API Doc - Devices: Device Code"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktDevice" /> instance, which contains a new device code, user code and a verification URL.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<ITraktDevice>> GenerateDeviceAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var request = new DeviceRequest
            {
                RequestBody = new DeviceRequestBody
                {
                    ClientId = clientId
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.GetDeviceAsync(request, cancellationToken);
        }

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="Device" />, <see cref="ClientId" /> and <see cref="ClientSecret" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationDeviceException">
        /// Thrown, if the current device has an invalid device code.
        /// Thrown, if the user code of the current device was already approved by the user.
        /// Thrown, if the current device code is already expired unused.
        /// Thrown, if the user explicitly denied the user code of the current device.
        /// </exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the current device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(Device, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="ClientId" /> and <see cref="ClientSecret" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="ITraktDevice" />, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationDeviceException">
        /// Thrown, if the given device has an invalid device code.
        /// Thrown, if the user code of the given device was already approved by the user.
        /// Thrown, if the given device code is already expired unused.
        /// Thrown, if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown, if the current client id is null, empty or contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, ClientId, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="ClientSecret" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="ITraktDevice" />, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationDeviceException">
        /// Thrown, if the given device has an invalid device code.
        /// Thrown, if the user code of the given device was already approved by the user.
        /// Thrown, if the given device code is already expired unused.
        /// Thrown, if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thrown, if the current client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, string clientId, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, clientId, ClientSecret, cancellationToken);

        /// <summary>
        /// Polls for a new access token. Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="ITraktDevice" />, which will be used for the request.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
        /// <exception cref="TraktAuthenticationDeviceException">
        /// Thrown, if the given device has an invalid device code.
        /// Thrown, if the user code of the given device was already approved by the user.
        /// Thrown, if the given device code is already expired unused.
        /// Thrown, if the user explicitly denied the user code of the given device.
        /// </exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given device is null, or already expired unused or invalid or its user code contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thrown, if the given client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationPollRequest
            {
                RequestBody = new AuthorizationPollRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Device = device
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.PollForAuthorizationAsync(request, cancellationToken);
        }

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="Authorization" />'s refresh token, <see cref="ClientId" />,
        /// <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(Authorization?.RefreshToken, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="ClientId" />, <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, ClientId, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="ClientSecret" /> and <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, ClientSecret, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Uses the current <see cref="RedirectUri" /> for the request.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, RedirectUri, cancellationToken);

        /// <summary>
        /// Exchanges the current refresh token for a new access token, without re-authenticating the associated user.
        /// Assigns the returned <see cref="ITraktAuthorization" /> instance to <see cref="Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-refresh_token-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="refreshToken">The refresh token, which will be used for the exchange.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="redirectUri">The redirect URI, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A new <see cref="ITraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRefreshRequest
            {
                RequestBody = new AuthorizationRefreshRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUri,
                    RefreshToken = refreshToken
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.RefreshAuthorizationAsync(request, cancellationToken);
        }

        /// <summary>
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="Authorization" />'s access token, <see cref="ClientId" /> and <see cref="ClientSecret" /> for the request.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(Authorization?.AccessToken, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="ClientId" /> and <see cref="ClientSecret" /> for the request.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(string accessToken, CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(accessToken, ClientId, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// Uses the current <see cref="ClientSecret" /> for the request.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(string accessToken, string clientId, CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(accessToken, clientId, ClientSecret, cancellationToken);

        /// <summary>
        /// Revokes the current access token. If, successful, the current access token will be invalid
        /// and the user has to be re-authenticated.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/revoke-an-access_token">"Trakt API Doc - OAuth: Revoke Token"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="accessToken">The given access token, which will be revoked.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktAuthorizationException">
        /// Thrown, if the current <see cref="TraktClient" /> instance is not authorized and the given access token is null,
        /// empty or contains spaces.
        /// </exception>
        /// <exception cref="TraktAuthenticationException">Thrown, if revoking the given access token fails with unknown error.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given access token is null, empty or contains spaces.
        /// Thrown, if the given client id is null, empty or contains spaces.
        /// Thrown, if the given client secret is null, empty or contains spaces.
        /// </exception>
        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(string accessToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRevokeRequest
            {
                RequestBody = new AuthorizationRevokeRequestBody
                {
                    AccessToken = accessToken,
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.RevokeAuthorizationAsync(request, cancellationToken);
        }
    }
}
