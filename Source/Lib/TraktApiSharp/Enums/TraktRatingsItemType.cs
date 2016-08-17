namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a rating item.</summary>
    public sealed class TraktRatingsItemType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktRatingsItemType Unspecified { get; } = new TraktRatingsItemType();

        /// <summary>The rating item contains a movie.</summary>
        public static TraktRatingsItemType Movie { get; } = new TraktRatingsItemType(1, "movie", "movies", "Movie");

        /// <summary>The ratingv item contains a show.</summary>
        public static TraktRatingsItemType Show { get; } = new TraktRatingsItemType(2, "show", "shows", "Show");

        /// <summary>The rating item contains a season.</summary>
        public static TraktRatingsItemType Season { get; } = new TraktRatingsItemType(4, "season", "seasons", "Season");

        /// <summary>The rating item contains an episode.</summary>
        public static TraktRatingsItemType Episode { get; } = new TraktRatingsItemType(8, "episode", "episodes", "Episode");

        /// <summary>The rating item contains a movie, show, season or an episode.</summary>
        public static TraktRatingsItemType All { get; } = new TraktRatingsItemType(16, "all", "all", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRatingsItemType" /> class.<para />
        /// The initialized <see cref="TraktRatingsItemType" /> is invalid.
        /// </summary>
        public TraktRatingsItemType() : base() { }

        private TraktRatingsItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
