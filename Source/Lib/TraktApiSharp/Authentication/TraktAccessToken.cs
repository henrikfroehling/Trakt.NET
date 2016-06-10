namespace TraktApiSharp.Authentication
{
    using Enums;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Represents a Trakt access token response.
    /// <para>
    /// See also <seealso cref="TraktOAuth.GetAccessTokenAsync()" />,
    /// <seealso cref="TraktOAuth.GetAccessTokenAsync(string)" />,
    /// <seealso cref="TraktOAuth.GetAccessTokenAsync(string, string)" />,
    /// <seealso cref="TraktOAuth.GetAccessTokenAsync(string, string, string)" /> or
    /// <seealso cref="TraktOAuth.GetAccessTokenAsync(string, string, string, string)" />.<para />
    /// See also <seealso cref="TraktDeviceAuth.PollForAccessTokenAsync()" />,
    /// <seealso cref="TraktDeviceAuth.PollForAccessTokenAsync(TraktDevice)" />,
    /// <seealso cref="TraktDeviceAuth.PollForAccessTokenAsync(TraktDevice, string)" />,
    /// <seealso cref="TraktDeviceAuth.PollForAccessTokenAsync(TraktDevice, string, string)" />.<para />
    /// See also <seealso cref="TraktAuthentication.AccessToken" />.<para />
    /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-oauth/get-token/exchange-code-for-access_token">"Trakt API Doc - OAuth: Get Token"</a> for more information.
    /// </para>
    /// </summary>
    public class TraktAccessToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAccessToken" /> class.
        /// <para>The instantiated token instance is invalid.</para>
        /// </summary>
        public TraktAccessToken()
        {
            Created = DateTime.UtcNow;
        }

        /// <summary>Gets or sets the actual access token.</summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the actual refresh token.</summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the token access scope. See also <seealso cref="TraktAccessScope" />.</summary>
        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(TraktAccessScopeConverter))]
        public TraktAccessScope AccessScope { get; set; }

        /// <summary>Gets or sets the seconds, after which this token will expire.</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        [JsonProperty(PropertyName = "token_type")]
        [JsonConverter(typeof(TraktAccessTokenTypeConverter))]
        public TraktAccessTokenType TokenType { get; set; }

        /// <summary>
        /// Returns, whether this token is valid.
        /// <para>
        /// A Trakt access token is valid, as long as the actual <see cref="AccessToken" />
        /// is neither null nor empty and as long as this token is not expired.<para />
        /// See also <seealso cref="ExpiresInSeconds" />.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(AccessToken) && DateTime.UtcNow.AddSeconds(ExpiresInSeconds) > DateTime.UtcNow;

        /// <summary>Gets the UTC DateTime, when this token was created.</summary>
        [JsonIgnore]
        public DateTime Created { get; private set; }
    }
}
