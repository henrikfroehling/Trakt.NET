namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    [Flags]
    public enum TraktSearchResultType
    {
        Unspecified = 0,
        Movie = 1,
        Show = 2,
        Episode = 4,
        Person = 8,
        List = 16
    }

    public static class TraktSearchResultTypeExtensions
    {
        public static string AsString(this TraktSearchResultType searchResultType)
        {
            if (searchResultType == TraktSearchResultType.Unspecified)
                return string.Empty;

            var flags = new List<string>();

            if (searchResultType.HasFlag(TraktSearchResultType.Movie))
                flags.Add("movie");

            if (searchResultType.HasFlag(TraktSearchResultType.Show))
                flags.Add("show");

            if (searchResultType.HasFlag(TraktSearchResultType.Episode))
                flags.Add("episode");

            if (searchResultType.HasFlag(TraktSearchResultType.Person))
                flags.Add("person");

            if (searchResultType.HasFlag(TraktSearchResultType.List))
                flags.Add("list");

            return string.Join(",", flags);

            //switch (searchResultType)
            //{
            //    case TraktSearchResultType.Movie: return "movie";
            //    case TraktSearchResultType.Show: return "show";
            //    case TraktSearchResultType.Episode: return "episode";
            //    case TraktSearchResultType.Person: return "person";
            //    case TraktSearchResultType.List: return "list";
            //    case TraktSearchResultType.Unspecified: return string.Empty;
            //    default:
            //        throw new NotSupportedException(searchResultType.ToString());
            //}
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
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktSearchResultType.Unspecified;

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
