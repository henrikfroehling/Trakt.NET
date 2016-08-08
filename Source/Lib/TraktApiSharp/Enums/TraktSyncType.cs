namespace TraktApiSharp.Enums
{
    public sealed class TraktSyncType : TraktEnumeration
    {
        public static TraktSyncType Unspecified { get; } = new TraktSyncType();
        public static TraktSyncType Movie { get; } = new TraktSyncType(1, "movie", "movies", "Movie");
        public static TraktSyncType Episode { get; } = new TraktSyncType(2, "episode", "episodes", "Episode");

        public TraktSyncType() : base() { }

        private TraktSyncType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
