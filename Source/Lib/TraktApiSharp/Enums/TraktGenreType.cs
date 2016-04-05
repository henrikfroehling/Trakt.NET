namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktGenreType
    {
        Shows,
        Movies
    }

    public static class TraktGenreTypeExtensions
    {
        public static string AsString(this TraktGenreType scope)
        {
            switch (scope)
            {
                case TraktGenreType.Shows: return "shows";
                case TraktGenreType.Movies: return "movies";
                default:
                    throw new ArgumentOutOfRangeException("GenreType");
            }
        }
    }

    public class TraktGenreTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktGenreType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var genreType = (TraktGenreType)value;
            writer.WriteValue(genreType.AsString());
        }
    }
}
