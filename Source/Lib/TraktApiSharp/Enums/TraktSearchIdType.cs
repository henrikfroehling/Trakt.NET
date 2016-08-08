namespace TraktApiSharp.Enums
{
    public sealed class TraktSearchIdType : TraktEnumeration
    {
        public static TraktSearchIdType Unspecified { get; } = new TraktSearchIdType();
        public static TraktSearchIdType Trakt { get; } = new TraktSearchIdType(1, "trakt", "trakt", "Trakt");
        public static TraktSearchIdType ImDB { get; } = new TraktSearchIdType(2, "imdb", "imdb", "Internet Movie Database");
        public static TraktSearchIdType TmDB { get; } = new TraktSearchIdType(4, "tmdb", "tmdb", "The Movie Database");
        public static TraktSearchIdType TvDB { get; } = new TraktSearchIdType(8, "tvdb", "tvdb", "TheTVDB");
        public static TraktSearchIdType TVRage { get; } = new TraktSearchIdType(16, "tvrage", "tvrage", "TVRage");

        public TraktSearchIdType() : base() { }

        private TraktSearchIdType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
