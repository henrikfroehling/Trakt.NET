namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktSearchIdLookupType
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

    public static class TraktSearchIdLookupTypeExtensions
    {
        public static string AsString(this TraktSearchIdLookupType searchIdLookupType)
        {
            switch (searchIdLookupType)
            {
                case TraktSearchIdLookupType.TraktMovie: return "trakt-movie";
                case TraktSearchIdLookupType.TraktShow: return "trakt-show";
                case TraktSearchIdLookupType.TraktEpisode: return "trakt-episode";
                case TraktSearchIdLookupType.ImDB: return "imdb";
                case TraktSearchIdLookupType.TmDB: return "tmdb";
                case TraktSearchIdLookupType.TvDB: return "tvdb";
                case TraktSearchIdLookupType.TVRage: return "tvrage";
                case TraktSearchIdLookupType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(searchIdLookupType.ToString());
            }
        }
    }

    public class TraktSearchIdLookupTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (enumString.Equals(TraktSearchIdLookupType.TraktMovie.AsString()))
                return TraktSearchIdLookupType.TraktMovie;
            else if (enumString.Equals(TraktSearchIdLookupType.TraktShow.AsString()))
                return TraktSearchIdLookupType.TraktShow;
            else if (enumString.Equals(TraktSearchIdLookupType.TraktEpisode.AsString()))
                return TraktSearchIdLookupType.TraktEpisode;
            else if (enumString.Equals(TraktSearchIdLookupType.ImDB.AsString()))
                return TraktSearchIdLookupType.ImDB;
            else if (enumString.Equals(TraktSearchIdLookupType.TmDB.AsString()))
                return TraktSearchIdLookupType.TmDB;
            else if (enumString.Equals(TraktSearchIdLookupType.TvDB.AsString()))
                return TraktSearchIdLookupType.TvDB;
            else if (enumString.Equals(TraktSearchIdLookupType.TVRage.AsString()))
                return TraktSearchIdLookupType.TVRage;

            return TraktSearchIdLookupType.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var searchIdLookupType = (TraktSearchIdLookupType)value;
            writer.WriteValue(searchIdLookupType.AsString());
        }
    }
}
