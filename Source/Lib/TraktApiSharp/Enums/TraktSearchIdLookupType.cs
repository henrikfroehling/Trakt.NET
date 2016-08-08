namespace TraktApiSharp.Enums
{
    public sealed class TraktSearchIdLookupType : TraktEnumeration
    {
        public static TraktSearchIdLookupType Unspecified { get; } = new TraktSearchIdLookupType();
        public static TraktSearchIdLookupType TraktMovie { get; } = new TraktSearchIdLookupType(1, "trakt-movie", "trakt-movie", "Trakt Movie");
        public static TraktSearchIdLookupType TraktShow { get; } = new TraktSearchIdLookupType(2, "trakt-show", "trakt-show", "Trakt Show");
        public static TraktSearchIdLookupType TraktEpisode { get; } = new TraktSearchIdLookupType(4, "trakt-episode", "trakt-episode", "Trakt Episode");
        public static TraktSearchIdLookupType ImDB { get; } = new TraktSearchIdLookupType(8, "imdb", "imdb", "Internet Movie Database");
        public static TraktSearchIdLookupType TmDB { get; } = new TraktSearchIdLookupType(16, "tmdb", "tmdb", "The Movie Database");
        public static TraktSearchIdLookupType TvDB { get; } = new TraktSearchIdLookupType(32, "tvdb", "tvdb", "TheTVDB");
        public static TraktSearchIdLookupType TVRage { get; } = new TraktSearchIdLookupType(64, "tvrage", "tvrage", "TVRage");

        public TraktSearchIdLookupType() : base() { }

        private TraktSearchIdLookupType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
