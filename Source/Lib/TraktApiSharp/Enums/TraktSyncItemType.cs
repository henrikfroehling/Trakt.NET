namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in an history item or in a watchlist item, .</summary>
    public sealed class TraktSyncItemType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktSyncItemType Unspecified { get; } = new TraktSyncItemType();

        /// <summary>The history or watchlist item contains a movie.</summary>
        public static TraktSyncItemType Movie { get; } = new TraktSyncItemType(1, "movie", "movies", "Movie");

        /// <summary>The history or watchlist item contains a show.</summary>
        public static TraktSyncItemType Show { get; } = new TraktSyncItemType(2, "show", "shows", "Show");

        /// <summary>The history or watchlist item contains a season.</summary>
        public static TraktSyncItemType Season { get; } = new TraktSyncItemType(4, "season", "seasons", "Season");

        /// <summary>The history or watchlist item contains an episode.</summary>
        public static TraktSyncItemType Episode { get; } = new TraktSyncItemType(8, "episode", "episodes", "Episode");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSyncItemType" /> class.<para />
        /// The initialized <see cref="TraktSyncItemType" /> is invalid.
        /// </summary>
        public TraktSyncItemType() : base() { }

        private TraktSyncItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
