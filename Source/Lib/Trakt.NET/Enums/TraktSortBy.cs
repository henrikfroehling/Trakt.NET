namespace TraktNet.Enums
{
    /// <summary>Determines how items are ordered.</summary>
    public sealed class TraktSortBy : TraktEnumeration
    {
        /// <summary>An invalid sort-by type.</summary>
        public static TraktSortBy Unspecified { get; } = new TraktSortBy();

        /// <summary>Items are ordered by rank.</summary>
        public static TraktSortBy Rank { get; } = new TraktSortBy(1, "rank", "rank", "Rank");

        /// <summary>Items are ordered by added timestamp.</summary>
        public static TraktSortBy Added { get; } = new TraktSortBy(2, "added", "added", "Added");

        /// <summary>Items are ordered by title.</summary>
        public static TraktSortBy Title { get; } = new TraktSortBy(4, "title", "title", "Title");

        /// <summary>Items are ordered by released timestamp.</summary>
        public static TraktSortBy Released { get; } = new TraktSortBy(8, "released", "released", "Released");

        /// <summary>Items are ordered by runtime.</summary>
        public static TraktSortBy Runtime { get; } = new TraktSortBy(16, "runtime", "runtime", "Runtime");

        /// <summary>Items are ordered by popularity.</summary>
        public static TraktSortBy Popularity { get; } = new TraktSortBy(32, "popularity", "popularity", "Popularity");

        /// <summary>Items are ordered by percentage.</summary>
        public static TraktSortBy Percentage { get; } = new TraktSortBy(64, "percentage", "percentage", "Percentage");

        /// <summary>Items are ordered by votes.</summary>
        public static TraktSortBy Votes { get; } = new TraktSortBy(128, "votes", "votes", "Votes");

        /// <summary>Items are ordered by own user rating.</summary>
        public static TraktSortBy MyRating { get; } = new TraktSortBy(512, "my_rating", "my_rating", "My Rating");

        /// <summary>Items are ordered by random.</summary>
        public static TraktSortBy Random { get; } = new TraktSortBy(1024, "random", "random", "Random");

        /// <summary>Items are ordered by watched timestamp.</summary>
        public static TraktSortBy Watched { get; } = new TraktSortBy(2048, "watched", "watched", "Watched");

        /// <summary>Items are ordered by collected timestamp.</summary>
        public static TraktSortBy Collected { get; } = new TraktSortBy(4096, "collected", "movies", "Collected");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSortBy" /> class.<para />
        /// The initialized <see cref="TraktSortBy" /> is invalid.
        /// </summary>
        public TraktSortBy()
        {
        }

        private TraktSortBy(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
