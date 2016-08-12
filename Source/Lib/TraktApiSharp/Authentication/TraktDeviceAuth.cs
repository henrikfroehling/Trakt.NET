namespace TraktApiSharp.Authentication
{
    using Core;
    using Exceptions;
    using Extensions;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;

    /// <summary>Provides access to Device authentication methods, such as creating a new device and polling for an access token.</summary>
    public class TraktDeviceAuth
    {
        internal TraktDeviceAuth(TraktClient client)
        {
            Client = client;
        }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; private set; }

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process. Uses the current <see cref="TraktAuthentication.ClientId" /> for the request.
        /// Assigns the returned <see cref="TraktDevice" /> instance to <see cref="TraktAuthentication.Device" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">"Trakt API Doc - Devices: Device Code"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GenerateDeviceAsync(string)" />.
        /// </para>
        /// </summary>
        /// <returns>A new <see cref="TraktDevice" /> instance, which contains a new device code, user code and a verification URL.</returns>
        /// <exception cref="ArgumentException">Thrown, if the current client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktDevice> GenerateDeviceAsync()
        {
            return await GenerateDeviceAsync(Client.ClientId);
        }

        /// <summary>
        /// Generates a new Trakt device and starts the device authentication process.
        /// Assigns the returned <see cref="TraktDevice" /> instance to <see cref="TraktAuthentication.Device" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">"Trakt API Doc - Devices: Device Code"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="GenerateDeviceAsync(string)" />.
        /// </para>
        /// </summary>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>A new <see cref="TraktDevice" /> instance, which contains a new device code, user code and a verification URL.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given client id is null, empty or contains spaces.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktDevice> GenerateDeviceAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceCodeUri}";
            var content = new StringContent(postContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(tokenUrl, content).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                await ErrorHandling(response, tokenUrl, postContent, true);

            var responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

            var device = default(TraktDevice);

            if (!string.IsNullOrEmpty(responseContent))
                device = Json.Deserialize<TraktDevice>(responseContent);

            Client.Authentication.Device = device;
            return device;
        }

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktAuthentication.Device" />, <see cref="TraktAuthentication.ClientId" /> and <see cref="TraktAuthentication.ClientSecret" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="PollForAuthorizationAsync(TraktDevice)" />,
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string)"/>
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public async Task<TraktAuthorization> PollForAuthorizationAsync()
        {
            return await PollForAuthorizationAsync(Client.Authentication.Device, Client.ClientId, Client.ClientSecret);
        }

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktAuthentication.ClientSecret" /> and <see cref="TraktAuthentication.ClientId" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="PollForAuthorizationAsync()" />,
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string)" /> and
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request. See also <seealso cref="TraktAuthentication.Device "/>.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device)
        {
            return await PollForAuthorizationAsync(device, Client.ClientId, Client.ClientSecret);
        }

        /// <summary>
        /// Polls for a new access token. Uses the current <see cref="TraktAuthentication.ClientSecret" /> for the request.
        /// Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="PollForAuthorizationAsync()" />,
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice)" /> and
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request. See also <seealso cref="TraktAuthentication.Device "/>.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device, string clientId)
        {
            return await PollForAuthorizationAsync(device, clientId, Client.ClientSecret);
        }

        /// <summary>
        /// Polls for a new access token. Assigns the returned <see cref="TraktAuthorization" /> instance to <see cref="TraktAuthentication.Authorization" />, if successful.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Devices: Get Token"</a> for more information.
        /// </para>
        /// <para>
        /// See also <seealso cref="PollForAuthorizationAsync()" />,
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice)" /> and
        /// <seealso cref="PollForAuthorizationAsync(TraktDevice, string)" />.
        /// See also <seealso cref="TraktAuthentication.Authorization" />.
        /// </para>
        /// </summary>
        /// <param name="device">The <see cref="TraktDevice" />, which will be used for the request. See also <seealso cref="TraktAuthentication.Device "/>.</param>
        /// <param name="clientId">The Trakt Client ID, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret, which will be used for the request. See also <seealso cref="TraktAuthentication.ClientSecret" />.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance, which contains a new access and refresh token.</returns>
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
        public async Task<TraktAuthorization> PollForAuthorizationAsync(TraktDevice device, string clientId, string clientSecret)
        {
            ValidateAccessTokenInput(device, clientId, clientSecret);

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var tokenUrl = $"{Client.Configuration.BaseUrl}{TraktConstants.OAuthDeviceTokenUri}";

            HttpStatusCode responseCode = default(HttpStatusCode);
            string responseContent = string.Empty;
            string reasonPhrase = string.Empty;
            int totalExpiredSeconds = 0;

            while (totalExpiredSeconds < device.ExpiresInSeconds)
            {
                var content = new StringContent(postContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(tokenUrl, content).ConfigureAwait(false);

                responseCode = response.StatusCode;
                reasonPhrase = response.ReasonPhrase;
                responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

                if (responseCode == HttpStatusCode.OK) // Success
                {
                    var token = default(TraktAuthorization);

                    if (!string.IsNullOrEmpty(responseContent))
                        token = Json.Deserialize<TraktAuthorization>(responseContent);

                    Client.Authentication.Authorization = token;
                    return token;
                }
                else if (responseCode == HttpStatusCode.BadRequest) // Pending
                {
                    await Task.Delay(device.IntervalInSeconds * 1000);
                    totalExpiredSeconds += device.IntervalInSeconds;
                    continue;
                }

                switch (responseCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new TraktAuthenticationDeviceException("Not Found - invalid device_code")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case HttpStatusCode.Conflict:   // Already Used
                        throw new TraktAuthenticationDeviceException("Already Used - user already approved this code")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case HttpStatusCode.Gone:       // Expired
                        throw new TraktAuthenticationDeviceException("Expired - the tokens have expired, restart the process")
                        {
                            StatusCode = responseCode,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case (HttpStatusCode)418:       // Denied
                        throw new TraktAuthenticationDeviceException("Denied - user explicitly denied this code")
                        {
                            StatusCode = (HttpStatusCode)418,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case (HttpStatusCode)429:       // Slow Down
                        throw new TraktAuthenticationDeviceException("Slow Down - your app is polling too quickly")
                        {
                            StatusCode = (HttpStatusCode)429,
                            RequestUrl = tokenUrl,
                            RequestBody = postContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                }

                await ErrorHandling(response, tokenUrl, postContent, true);
                break;
            }

            throw new TraktAuthenticationDeviceException("unknown exception") { ServerReasonPhrase = reasonPhrase };
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
        {
            return await Client.Authentication.RefreshAuthorizationAsync();
        }

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
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken);
        }

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
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId);
        }

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
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret);
        }

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
        public async Task<TraktAuthorization> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri)
        {
            return await Client.Authentication.RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, redirectUri);
        }

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

        private void ValidateAccessTokenInput(TraktDevice device, string clientId, string clientSecret)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device), "device must not be null");

            if (device.IsExpiredUnused)
                throw new ArgumentException("device code expired unused", nameof(device));

            if (!device.IsValid)
                throw new ArgumentException("device not valid", nameof(device));

            if (device.DeviceCode.ContainsSpace())
                throw new ArgumentException("device code not valid", nameof(device.DeviceCode));

            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(clientSecret) || clientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(clientSecret));
        }

        private async Task ErrorHandling(HttpResponseMessage response, string requestUrl, string requestContent, bool handleAdditionalCodes)
        {
            var responseContent = string.Empty;

            if (response.Content != null)
                responseContent = await response.Content.ReadAsStringAsync();

            var code = response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;

            switch (code)
            {
                case HttpStatusCode.Unauthorized:
                    throw new TraktAuthorizationException
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

            if (handleAdditionalCodes)
            {
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
                    case (HttpStatusCode)429:
                        throw new TraktRateLimitException
                        {
                            RequestUrl = requestUrl,
                            RequestBody = requestContent,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                }
            }

            throw new TraktAuthenticationDeviceException("unknown error")
            {
                StatusCode = code,
                RequestUrl = requestUrl,
                RequestBody = requestContent,
                Response = responseContent,
                ServerReasonPhrase = reasonPhrase
            };
        }
    }
}
