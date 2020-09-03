namespace TraktNet.Enums
{
    /// <summary>Determines the sort order for watchlists.</summary>
    public sealed class TraktWatchlistSortOrder : TraktEnumeration
    {
        /// <summary>An invalid sort order.</summary>
        public static TraktWatchlistSortOrder Unspecified { get; } = new TraktWatchlistSortOrder();

        /// <summary>Watchlists will be sorted by rank.</summary>
        public static TraktWatchlistSortOrder Rank { get; } = new TraktWatchlistSortOrder(1, "rank", "rank", "Rank");

        /// <summary>Watchlists will be sorted by recently added items first.</summary>
        public static TraktWatchlistSortOrder Added { get; } = new TraktWatchlistSortOrder(2, "added", "added", "Added");

        /// <summary>Watchlists will be sorted by recently released items first.</summary>
        public static TraktWatchlistSortOrder Released { get; } = new TraktWatchlistSortOrder(4, "released", "released", "Released");

        /// <summary>Watchlists will be sorted by title.</summary>
        public static TraktWatchlistSortOrder Title { get; } = new TraktWatchlistSortOrder(8, "title", "title", "Title");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListSortOrder" /> class.<para />
        /// The initialized <see cref="TraktWatchlistSortOrder" /> is invalid.
        /// </summary>
        public TraktWatchlistSortOrder()
        {
        }

        private TraktWatchlistSortOrder(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
