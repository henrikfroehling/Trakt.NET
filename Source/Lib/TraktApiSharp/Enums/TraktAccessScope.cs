namespace TraktApiSharp.Enums
{
    /// <summary>Determines the access authorization for different resources.</summary>
    public sealed class TraktAccessScope : TraktEnumeration
    {
        /// <summary>An invalid access scope.</summary>
        public static TraktAccessScope Unspecified { get; } = new TraktAccessScope();

        /// <summary>A resource can be accessed by all.</summary>
        public static TraktAccessScope Public { get; } = new TraktAccessScope(1, "public", "public", "Public");

        /// <summary>A resource can only be accessed by the user.</summary>
        public static TraktAccessScope Private { get; } = new TraktAccessScope(2, "private", "private", "Private");

        /// <summary>A resource can only be accessed by friends of an user.</summary>
        public static TraktAccessScope Friends { get; } = new TraktAccessScope(4, "friends", "friends", "Friends");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAccessScope" /> class.<para />
        /// The initialized <see cref="TraktAccessScope" /> is invalid.
        /// </summary>
        public TraktAccessScope() : base() { }

        private TraktAccessScope(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
