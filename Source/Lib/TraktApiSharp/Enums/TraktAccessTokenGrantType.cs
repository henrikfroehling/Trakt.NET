namespace TraktApiSharp.Enums
{
    /// <summary>Determines the grant type to specify how an access tokenshould be retrieved during authentication.</summary>
    public sealed class TraktAccessTokenGrantType : TraktEnumeration
    {
        /// <summary>An invalid access token grant type.</summary>
        public static TraktAccessTokenGrantType Unspecified { get; } = new TraktAccessTokenGrantType();

        /// <summary>The grant type to specify the retrieving of an access token with an user code.</summary>
        public static TraktAccessTokenGrantType AuthorizationCode { get; } = new TraktAccessTokenGrantType(1, "authorization_code", "authorization_code", "Authorization Code");

        /// <summary>The grant type to specify the retrieving of an access token with a refresh token.</summary>
        public static TraktAccessTokenGrantType RefreshToken { get; } = new TraktAccessTokenGrantType(2, "refresh_token", "refresh_token", "Refresh Token");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAccessTokenGrantType" /> class.<para />
        /// The initialized <see cref="TraktAccessTokenGrantType" /> is invalid.
        /// </summary>
        public TraktAccessTokenGrantType() : base() { }

        private TraktAccessTokenGrantType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
