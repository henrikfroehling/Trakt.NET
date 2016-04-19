namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktSearchLookupIdType
    {
        Unspecified,
        TraktMovie,
        TraktShow,
        TraktEpisode,
        ImDB,
        TmDB,
        TvDB,
        TVRage
    }

    public static class TraktSearchLookupIdTypeExtensions
    {
        public static string AsString(this TraktSearchLookupIdType searchLookupIdType)
        {
            switch (searchLookupIdType)
            {
                case TraktSearchLookupIdType.TraktMovie: return "trakt-movie";
                case TraktSearchLookupIdType.TraktShow: return "trakt-show";
                case TraktSearchLookupIdType.TraktEpisode: return "trakt-episode";
                case TraktSearchLookupIdType.ImDB: return "imdb";
                case TraktSearchLookupIdType.TmDB: return "tmdb";
                case TraktSearchLookupIdType.TvDB: return "tvdb";
                case TraktSearchLookupIdType.TVRage: return "tvrage";
                case TraktSearchLookupIdType.Unspecified: return string.Empty;
                default:
                    throw new ArgumentOutOfRangeException("AccessScope");
            }
        }
    }

    public class TraktSearchLookupIdTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (enumString.Equals(TraktSearchLookupIdType.TraktMovie.AsString()))
                return TraktSearchLookupIdType.TraktMovie;
            else if (enumString.Equals(TraktSearchLookupIdType.TraktShow.AsString()))
                return TraktSearchLookupIdType.TraktShow;
            else if (enumString.Equals(TraktSearchLookupIdType.TraktEpisode.AsString()))
                return TraktSearchLookupIdType.TraktEpisode;
            else if (enumString.Equals(TraktSearchLookupIdType.ImDB.AsString()))
                return TraktSearchLookupIdType.ImDB;
            else if (enumString.Equals(TraktSearchLookupIdType.TmDB.AsString()))
                return TraktSearchLookupIdType.TmDB;
            else if (enumString.Equals(TraktSearchLookupIdType.TvDB.AsString()))
                return TraktSearchLookupIdType.TvDB;
            else if (enumString.Equals(TraktSearchLookupIdType.TVRage.AsString()))
                return TraktSearchLookupIdType.TVRage;

            return TraktSearchLookupIdType.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var searchLookupIdType = (TraktSearchLookupIdType)value;
            writer.WriteValue(searchLookupIdType.AsString());
        }
    }
}
