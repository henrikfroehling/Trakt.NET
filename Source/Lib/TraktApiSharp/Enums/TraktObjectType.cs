namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktObjectType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode,
        List,
        All
    }

    public static class TraktObjectTypeExtensions
    {
        public static string AsString(this TraktObjectType objectType)
        {
            switch (objectType)
            {
                case TraktObjectType.Movie: return "movie";
                case TraktObjectType.Show: return "show";
                case TraktObjectType.Season: return "season";
                case TraktObjectType.Episode: return "episode";
                case TraktObjectType.List: return "list";
                case TraktObjectType.All:
                case TraktObjectType.Unspecified:
                    return string.Empty;
                default:
                    throw new NotSupportedException(objectType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktObjectType objectType)
        {
            switch (objectType)
            {
                case TraktObjectType.Movie: return "movies";
                case TraktObjectType.Show: return "shows";
                case TraktObjectType.Season: return "seasons";
                case TraktObjectType.Episode: return "episodes";
                case TraktObjectType.List: return "lists";
                case TraktObjectType.All: return "all";
                case TraktObjectType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(objectType.ToString());
            }
        }
    }

    public class TraktObjectTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktObjectType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktObjectType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = (TraktObjectType)value;
            writer.WriteValue(objectType.AsString());
        }
    }
}
