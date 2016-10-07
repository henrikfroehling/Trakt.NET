namespace TraktApiSharp.Authentication
{
    using Enums;
    using Extensions;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Represents a Trakt authorization response, which contains information, such as access token and refresh token.
    /// <para>
    /// See also <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync()" />,
    /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice)" />,
    /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice, string)" />,
    /// <seealso cref="TraktDeviceAuth.PollForAuthorizationAsync(TraktDevice, string, string)" />,
    /// <seealso cref="TraktOAuth.GetAuthorizationAsync()" />, <seealso cref="TraktOAuth.GetAuthorizationAsync(string)" />,
    /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string)" />, <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string)" />,
    /// <seealso cref="TraktOAuth.GetAuthorizationAsync(string, string, string, string)" />,
    /// <seealso cref="TraktAuthentication.RefreshAuthorizationAsync()" />,
    /// <seealso cref="TraktAuthentication.RefreshAuthorizationAsync(string)" />, <seealso cref="TraktAuthentication.RefreshAuthorizationAsync(string, string)" />,
    /// <seealso cref="TraktAuthentication.RefreshAuthorizationAsync(string, string, string)" /> and
    /// <seealso cref="TraktAuthentication.RefreshAuthorizationAsync(string, string, string, string)" />.<para />
    /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> and
    /// <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/get-token/poll-for-the-access_token">"Trakt API Doc - Device: Get Token"</a> for more information.
    /// </para>
    /// </summary>
    public class TraktAuthorization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthorization" /> class.
        /// <para>
        /// Sets <see cref="Created" /> to the DateTime, when it is initialized.
        /// The instantiated authorization instance is invalid.
        /// </para>
        /// </summary>
        public TraktAuthorization() { Created = DateTime.UtcNow; }

        /// <summary>Gets or sets the access token.</summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token. Use this to exchange it for a new access token.</summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the token scope. See also <seealso cref="TraktAccessScope" />.</summary>
        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
        public TraktAccessScope AccessScope { get; set; }

        /// <summary>Gets or sets the seconds, after which this authorization will expire.</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        [JsonProperty(PropertyName = "token_type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessTokenType>))]
        public TraktAccessTokenType TokenType { get; set; }

        /// <summary>
        /// Returns, whether this authorization information is expired.
        /// <para>
        /// Returns false, if <see cref="IsValid" /> returns false, or, if the authorization information is expired.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => !IsValid || (IgnoreExpiration ? false : Created.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow);

        /// <summary>
        /// Returns, whether this authorization information is valid.
        /// <para>
        /// Returns false, if <see cref="AccessToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(AccessToken) && !AccessToken.ContainsSpace();

        /// <summary>
        /// Returns, whether this authorization information can be refreshed with a refresh token.
        /// <para>
        /// Returns false, if <see cref="RefreshToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsRefreshPossible => !string.IsNullOrEmpty(RefreshToken) && !RefreshToken.ContainsSpace();

        /// <summary>Returns the UTC DateTime, when this authorization information was created.</summary>
        [JsonIgnore]
        public DateTime Created { get; internal set; }

        [JsonIgnore]
        internal bool IgnoreExpiration { get; set; }

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(string accessToken, string refreshToken = null)
            => new TraktAuthorization
            {
                AccessScope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer,
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty,
                IgnoreExpiration = true
            };

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(int expiresInSeconds, string accessToken, string refreshToken = null)
            => new TraktAuthorization
            {
                ExpiresInSeconds = expiresInSeconds,
                AccessScope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer,
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty
            };

        /// <summary>
        /// Creates a new <see cref="TraktAuthorization" /> instance with the given values.
        /// <see cref="ExpiresInSeconds" /> of the created <see cref="TraktAuthorization" /> instance will have the default
        /// value of 3600 * 24 * 90 seconds, equal to 90 days.
        /// </summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(DateTime createdAt, string accessToken, string refreshToken = null)
            => new TraktAuthorization
            {
                Created = createdAt.ToUniversalTime(),
                ExpiresInSeconds = 3600 * 24 * 90,
                AccessScope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer,
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty
            };

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(DateTime createdAt, int expiresInSeconds,
                                                    string accessToken, string refreshToken = null)
            => new TraktAuthorization
            {
                Created = createdAt.ToUniversalTime(),
                ExpiresInSeconds = expiresInSeconds,
                AccessScope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer,
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty
            };
    }
}
