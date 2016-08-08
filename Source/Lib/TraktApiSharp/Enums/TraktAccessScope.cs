namespace TraktApiSharp.Enums
{
    public sealed class TraktAccessScope : TraktEnumeration
    {
        public static TraktAccessScope Unspecified { get; } = new TraktAccessScope();
        public static TraktAccessScope Public { get; } = new TraktAccessScope(1, "public", "public", "Public");
        public static TraktAccessScope Private { get; } = new TraktAccessScope(2, "private", "private", "Private");
        public static TraktAccessScope Friends { get; } = new TraktAccessScope(4, "friends", "friends", "Friends");

        public TraktAccessScope() : base() { }

        private TraktAccessScope(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
