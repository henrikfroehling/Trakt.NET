namespace TraktApiSharp.Enums
{
    /// <summary>Determines the id type, for which should be searched in an id lookup request.</summary>
    public sealed class TraktSearchIdLookupType : TraktEnumeration
    {
        /// <summary>An invalid id type.</summary>
        public static TraktSearchIdLookupType Unspecified { get; } = new TraktSearchIdLookupType();

        /// <summary>Search for Trakt movie ids.</summary>
        public static TraktSearchIdLookupType TraktMovie { get; } = new TraktSearchIdLookupType(1, "trakt-movie", "trakt-movie", "Trakt Movie");

        /// <summary>Search for Trakt show ids.</summary>
        public static TraktSearchIdLookupType TraktShow { get; } = new TraktSearchIdLookupType(2, "trakt-show", "trakt-show", "Trakt Show");

        /// <summary>Search for Trakt episode ids.</summary>
        public static TraktSearchIdLookupType TraktEpisode { get; } = new TraktSearchIdLookupType(4, "trakt-episode", "trakt-episode", "Trakt Episode");

        /// <summary>Search for ImDB ids.</summary>
        public static TraktSearchIdLookupType ImDB { get; } = new TraktSearchIdLookupType(8, "imdb", "imdb", "Internet Movie Database");

        /// <summary>Search for TmDB ids.</summary>
        public static TraktSearchIdLookupType TmDB { get; } = new TraktSearchIdLookupType(16, "tmdb", "tmdb", "The Movie Database");

        /// <summary>Search for TvDB ids.</summary>
        public static TraktSearchIdLookupType TvDB { get; } = new TraktSearchIdLookupType(32, "tvdb", "tvdb", "TheTVDB");

        /// <summary>Search for TVRage ids.</summary>
        public static TraktSearchIdLookupType TVRage { get; } = new TraktSearchIdLookupType(64, "tvrage", "tvrage", "TVRage");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSearchIdLookupType" /> class.<para />
        /// The initialized <see cref="TraktSearchIdLookupType" /> is invalid.
        /// </summary>
        public TraktSearchIdLookupType() : base() { }

        private TraktSearchIdLookupType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
