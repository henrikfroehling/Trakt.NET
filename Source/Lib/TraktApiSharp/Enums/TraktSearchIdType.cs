namespace TraktApiSharp.Enums
{
    /// <summary>Determines the id type, for which should be searched in an id lookup request.</summary>
    public sealed class TraktSearchIdType : TraktEnumeration
    {
        /// <summary>An invalid id type.</summary>
        public static TraktSearchIdType Unspecified { get; } = new TraktSearchIdType();

        /// <summary>Search for Trakt ids.</summary>
        public static TraktSearchIdType Trakt { get; } = new TraktSearchIdType(1, "trakt", "trakt", "Trakt");

        /// <summary>Search for ImDB ids.</summary>
        public static TraktSearchIdType ImDB { get; } = new TraktSearchIdType(2, "imdb", "imdb", "Internet Movie Database");

        /// <summary>Search for TmDB ids.</summary>
        public static TraktSearchIdType TmDB { get; } = new TraktSearchIdType(4, "tmdb", "tmdb", "The Movie Database");

        /// <summary>Search for TvDB ids.</summary>
        public static TraktSearchIdType TvDB { get; } = new TraktSearchIdType(8, "tvdb", "tvdb", "TheTVDB");

        /// <summary>Search for TVRage ids.</summary>
        public static TraktSearchIdType TVRage { get; } = new TraktSearchIdType(16, "tvrage", "tvrage", "TVRage");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSearchIdType" /> class.<para />
        /// The initialized <see cref="TraktSearchIdType" /> is invalid.
        /// </summary>
        public TraktSearchIdType() : base() { }

        private TraktSearchIdType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
