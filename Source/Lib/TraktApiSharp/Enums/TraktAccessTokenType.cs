namespace TraktApiSharp.Enums
{
    public sealed class TraktAccessTokenType : TraktEnumeration
    {
        public static TraktAccessTokenType Unspecified { get; } = new TraktAccessTokenType();
        public static TraktAccessTokenType Bearer { get; } = new TraktAccessTokenType(1, "bearer", "bearer", "Bearer");

        public TraktAccessTokenType() : base() { }

        private TraktAccessTokenType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
