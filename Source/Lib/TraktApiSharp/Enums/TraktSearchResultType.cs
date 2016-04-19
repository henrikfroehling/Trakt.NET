namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSearchResultType
    {
        Unspecified,
        Movie,
        Show,
        Episode,
        Person,
        List
    }

    public static class TraktSearchResultTypeExtensions
    {
        public static string AsString(this TraktSearchResultType searchResultType)
        {
            switch (searchResultType)
            {
                case TraktSearchResultType.Movie: return "movie";
                case TraktSearchResultType.Show: return "show";
                case TraktSearchResultType.Episode: return "episode";
                case TraktSearchResultType.Person: return "person";
                case TraktSearchResultType.List: return "list";
                case TraktSearchResultType.Unspecified: return "";
                default:
                    throw new ArgumentOutOfRangeException("SearchResultType");
            }
        }
    }

    public class TraktSearchResultTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSearchResultType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var searchResultType = (TraktSearchResultType)value;
            writer.WriteValue(searchResultType.AsString());
        }
    }
}
