namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSearchResultType
    {
        Movie,
        Show,
        Episode,
        Person,
        List
    }

    public static class TraktSearchResultTypeExtensions
    {
        public static string AsString(this TraktSearchResultType scope)
        {
            switch (scope)
            {
                case TraktSearchResultType.Movie: return "movie";
                case TraktSearchResultType.Show: return "show";
                case TraktSearchResultType.Episode: return "episode";
                case TraktSearchResultType.Person: return "person";
                case TraktSearchResultType.List: return "list";
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
            var resultType = (TraktSearchResultType)value;
            writer.WriteValue(resultType.AsString());
        }
    }
}
