namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktSearchIdType
    {
        Unspecified,
        Trakt,
        ImDB,
        TmDB,
        TvDB,
        TVRage
    }

    public static class TraktSearchIdTypeExtensions
    {
        public static string AsString(this TraktSearchIdType searchIdType)
        {
            switch (searchIdType)
            {
                case TraktSearchIdType.Trakt: return "trakt";
                case TraktSearchIdType.ImDB: return "imdb";
                case TraktSearchIdType.TmDB: return "tmdb";
                case TraktSearchIdType.TvDB: return "tvdb";
                case TraktSearchIdType.TVRage: return "tvrage";
                case TraktSearchIdType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(searchIdType.ToString());
            }
        }
    }

}
