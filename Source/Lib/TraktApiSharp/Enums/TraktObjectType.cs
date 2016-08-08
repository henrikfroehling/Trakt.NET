namespace TraktApiSharp.Enums
{
    public sealed class TraktObjectType : TraktEnumeration
    {
        public static TraktObjectType Unspecified { get; } = new TraktObjectType();
        public static TraktObjectType Movie { get; } = new TraktObjectType(1, "movie", "movies", "Movie");
        public static TraktObjectType Show { get; } = new TraktObjectType(2, "show", "shows", "Show");
        public static TraktObjectType Season { get; } = new TraktObjectType(4, "season", "seasons", "Season");
        public static TraktObjectType Episode { get; } = new TraktObjectType(8, "episode", "episodes", "Episode");
        public static TraktObjectType List { get; } = new TraktObjectType(16, "list", "lists", "List");
        public static TraktObjectType All { get; } = new TraktObjectType(32, string.Empty, "all", "All");

        public TraktObjectType() : base() { }

        private TraktObjectType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
