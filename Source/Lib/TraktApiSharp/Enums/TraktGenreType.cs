namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktGenreType
    {
        Unspecified,
        Shows,
        Movies
    }

    public static class TraktGenreTypeExtensions
    {
        public static string AsString(this TraktGenreType genreType)
        {
            switch (genreType)
            {
                case TraktGenreType.Shows: return "shows";
                case TraktGenreType.Movies: return "movies";
                case TraktGenreType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(genreType.ToString());
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
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktGenreType.Unspecified;

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
