namespace TraktApiSharp.Enums
{
    public sealed class TraktSyncItemType : TraktEnumeration
    {
        public static TraktSyncItemType Unspecified { get; } = new TraktSyncItemType();
        public static TraktSyncItemType Movie { get; } = new TraktSyncItemType(1, "movie", "movies", "Movie");
        public static TraktSyncItemType Show { get; } = new TraktSyncItemType(2, "show", "shows", "Show");
        public static TraktSyncItemType Season { get; } = new TraktSyncItemType(4, "season", "seasons", "Season");
        public static TraktSyncItemType Episode { get; } = new TraktSyncItemType(8, "episode", "episodes", "Episode");

        public TraktSyncItemType() : base() { }

        private TraktSyncItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
