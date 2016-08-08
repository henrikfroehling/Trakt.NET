namespace TraktApiSharp.Enums
{
    public sealed class TraktAccessTokenGrantType : TraktEnumeration
    {
        public static TraktAccessTokenGrantType Unspecified { get; } = new TraktAccessTokenGrantType();
        public static TraktAccessTokenGrantType AuthorizationCode { get; } = new TraktAccessTokenGrantType(1, "authorization_code", "authorization_code", "Authorization Code");
        public static TraktAccessTokenGrantType RefreshToken { get; } = new TraktAccessTokenGrantType(2, "refresh_token", "refresh_token", "Refresh Token");

        public TraktAccessTokenGrantType() : base() { }

        private TraktAccessTokenGrantType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
