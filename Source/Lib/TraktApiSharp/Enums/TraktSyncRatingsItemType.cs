namespace TraktApiSharp.Enums
{
    public sealed class TraktSyncRatingsItemType : TraktEnumeration
    {
        public static TraktSyncRatingsItemType Unspecified { get; } = new TraktSyncRatingsItemType();
        public static TraktSyncRatingsItemType Movie { get; } = new TraktSyncRatingsItemType(1, "movie", "movies", "Movie");
        public static TraktSyncRatingsItemType Show { get; } = new TraktSyncRatingsItemType(2, "show", "shows", "Show");
        public static TraktSyncRatingsItemType Season { get; } = new TraktSyncRatingsItemType(4, "season", "seasons", "Season");
        public static TraktSyncRatingsItemType Episode { get; } = new TraktSyncRatingsItemType(8, "episode", "episodes", "Episode");
        public static TraktSyncRatingsItemType All { get; } = new TraktSyncRatingsItemType(16, "all", "all", "All");

        public TraktSyncRatingsItemType() : base() { }

        private TraktSyncRatingsItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
