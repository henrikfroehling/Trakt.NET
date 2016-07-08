namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktListItemType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode,
        Person
    }

    public static class TraktListItemTypeExtensions
    {
        public static string AsString(this TraktListItemType listItemType)
        {
            switch (listItemType)
            {
                case TraktListItemType.Movie: return "movie";
                case TraktListItemType.Show: return "show";
                case TraktListItemType.Season: return "season";
                case TraktListItemType.Episode: return "episode";
                case TraktListItemType.Person: return "person";
                case TraktListItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(listItemType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktListItemType listItemType)
        {
            switch (listItemType)
            {
                case TraktListItemType.Movie: return "movies";
                case TraktListItemType.Show: return "shows";
                case TraktListItemType.Season: return "seasons";
                case TraktListItemType.Episode: return "episodes";
                case TraktListItemType.Person: return "people";
                case TraktListItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(listItemType.ToString());
            }
        }
    }

    public class TraktListItemTypeConverter : JsonConverter
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
                return TraktListItemType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktListItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var listItemType = (TraktListItemType)value;
            writer.WriteValue(listItemType.AsString());
        }
    }
}
