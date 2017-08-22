namespace TraktApiSharp.Enums
{
    /// <summary>Determines the list type.</summary>
    public sealed class TraktListType : TraktEnumeration
    {
        /// <summary>An invalid list type.</summary>
        public static TraktListType Unspecified { get; } = new TraktListType();

        /// <summary>The list type for personal lists.</summary>
        public static TraktListType Personal { get; } = new TraktListType(1, "personal", "personal", "Personal");

        /// <summary>The list type for official lists.</summary>
        public static TraktListType Official { get; } = new TraktListType(2, "official", "official", "Official");

        /// <summary>The list type for watchlists.</summary>
        public static TraktListType Watchlist { get; } = new TraktListType(4, "watchlists", "watchlists", "Watchlists");

        /// <summary>The list type for personal, official lists and watchlists together.</summary>
        public static TraktListType All { get; } = new TraktListType(8, "all ", "all ", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListType" /> class.<para />
        /// The initialized <see cref="TraktListType" /> is invalid.
        /// </summary>
        public TraktListType()
        {
        }

        private TraktListType(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
