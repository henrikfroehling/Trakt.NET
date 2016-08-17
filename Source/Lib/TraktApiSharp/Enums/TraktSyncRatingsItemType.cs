namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a rating item.</summary>
    public sealed class TraktSyncRatingsItemType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktSyncRatingsItemType Unspecified { get; } = new TraktSyncRatingsItemType();

        /// <summary>The rating item contains a movie.</summary>
        public static TraktSyncRatingsItemType Movie { get; } = new TraktSyncRatingsItemType(1, "movie", "movies", "Movie");

        /// <summary>The ratingv item contains a show.</summary>
        public static TraktSyncRatingsItemType Show { get; } = new TraktSyncRatingsItemType(2, "show", "shows", "Show");

        /// <summary>The rating item contains a season.</summary>
        public static TraktSyncRatingsItemType Season { get; } = new TraktSyncRatingsItemType(4, "season", "seasons", "Season");

        /// <summary>The rating item contains an episode.</summary>
        public static TraktSyncRatingsItemType Episode { get; } = new TraktSyncRatingsItemType(8, "episode", "episodes", "Episode");

        /// <summary>The rating item contains a movie, show, season or an episode.</summary>
        public static TraktSyncRatingsItemType All { get; } = new TraktSyncRatingsItemType(16, "all", "all", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSyncRatingsItemType" /> class.<para />
        /// The initialized <see cref="TraktSyncRatingsItemType" /> is invalid.
        /// </summary>
        public TraktSyncRatingsItemType() : base() { }

        private TraktSyncRatingsItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
