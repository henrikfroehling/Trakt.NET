namespace TraktApiSharp.Enums
{
    public sealed class TraktSearchResultType : TraktEnumeration
    {
        public static TraktSearchResultType Unspecified { get; } = new TraktSearchResultType();
        public static TraktSearchResultType Movie { get; } = new TraktSearchResultType(1, "movie", "movie", "Movie");
        public static TraktSearchResultType Show { get; } = new TraktSearchResultType(2, "show", "show", "Show");
        public static TraktSearchResultType Episode { get; } = new TraktSearchResultType(4, "episode", "episode", "Episode");
        public static TraktSearchResultType Person { get; } = new TraktSearchResultType(8, "person", "person", "Person");
        public static TraktSearchResultType List { get; } = new TraktSearchResultType(16, "list", "list", "List");

        public TraktSearchResultType() : base() { }

        private TraktSearchResultType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        public static TraktSearchResultType operator |(TraktSearchResultType first, TraktSearchResultType second)
        {
            if (first == null || second == null)
                return null;

            if (first == Unspecified || second == Unspecified)
                return Unspecified;

            var newValue = first.Value | second.Value;
            var newObjectName = string.Join(",", first.ObjectName, second.ObjectName);
            var newUriName = string.Join(",", first.UriName, second.UriName);
            var newDisplayName = string.Join(", ", first.DisplayName, second.DisplayName);

            return new TraktSearchResultType(newValue, newObjectName, newUriName, newDisplayName);
        }
    }
}
