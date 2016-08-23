namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an access token.</summary>
    public sealed class TraktAccessTokenType : TraktEnumeration
    {
        /// <summary>An invalid access token type.</summary>
        public static TraktAccessTokenType Unspecified { get; } = new TraktAccessTokenType();

        /// <summary>The access token type for Bearer tokens.</summary>
        public static TraktAccessTokenType Bearer { get; } = new TraktAccessTokenType(1, "bearer", "bearer", "Bearer");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAccessTokenType" /> class.<para />
        /// The initialized <see cref="TraktAccessTokenType" /> is invalid.
        /// </summary>
        public TraktAccessTokenType() : base() { }

        private TraktAccessTokenType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
