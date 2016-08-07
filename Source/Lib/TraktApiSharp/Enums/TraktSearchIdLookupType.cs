namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

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

            if (string.IsNullOrEmpty(enumString))
                return TraktSearchIdLookupType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktSearchIdLookupType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var searchIdLookupType = (TraktSearchIdLookupType)value;
            writer.WriteValue(searchIdLookupType.ObjectName);
        }
    }
}
