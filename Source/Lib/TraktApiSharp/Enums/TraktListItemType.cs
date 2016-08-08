namespace TraktApiSharp.Enums
{
    public sealed class TraktListItemType : TraktEnumeration
    {
        public static TraktListItemType Unspecified { get; } = new TraktListItemType();
        public static TraktListItemType Movie { get; } = new TraktListItemType(1, "movie", "movies", "Movie");
        public static TraktListItemType Show { get; } = new TraktListItemType(2, "show", "shows", "Show");
        public static TraktListItemType Season { get; } = new TraktListItemType(4, "season", "seasons", "Season");
        public static TraktListItemType Episode { get; } = new TraktListItemType(8, "episode", "episodes", "Episode");
        public static TraktListItemType Person { get; } = new TraktListItemType(16, "person", "people", "Person");

        public TraktListItemType() : base() { }

        private TraktListItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
