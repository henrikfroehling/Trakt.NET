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
        public TraktAuthorization()
        {
            Created = DateTime.UtcNow;
        }

        /// <summary>Gets or sets the access token. See also <seealso cref="TraktClient.AccessToken" />.</summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token. Use this to exchange it for a new access token.</summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the token scope. See also <seealso cref="TraktAccessScope" />.</summary>
        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
        public TraktAccessScope AccessScope { get; set; }

        /// <summary>Gets or sets the epoch value, after which this authorization will expire.</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>Gets or sets the seconds, after which this authorization will expire.</summary>
        [JsonIgnore]
        public int ExpiresInSeconds => ExpiresIn * 1000;

        /// <summary>Gets or sets the token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        [JsonProperty(PropertyName = "token_type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessTokenType>))]
        public TraktAccessTokenType TokenType { get; set; }

        /// <summary>
        /// Returns, whether this authorization information is not expired yet.
        /// <para>
        /// Returns false, if <see cref="AccessToken" /> is null, empty or contains spaces, or,
        /// if the authorization information is expired.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => !string.IsNullOrEmpty(AccessToken) && !AccessToken.ContainsSpace()
                                    && (IgnoreExpiration || (DateTime.UtcNow.AddSeconds(ExpiresInSeconds) > DateTime.UtcNow));

        /// <summary>Returns the UTC DateTime, when this authorization information was created.</summary>
        [JsonIgnore]
        public DateTime Created { get; private set; }

        [JsonIgnore]
        internal bool IgnoreExpiration { get; set; }
    }
}
