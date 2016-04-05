namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktHiddenItemType
    {
        Movie,
        Show,
        Season
    }

    public static class TraktHiddenItemTypeExtensions
    {
        public static string AsString(this TraktHiddenItemType scope)
        {
            switch (scope)
            {
                case TraktHiddenItemType.Movie: return "movie";
                case TraktHiddenItemType.Show: return "show";
                case TraktHiddenItemType.Season: return "season";
                default:
                    throw new ArgumentOutOfRangeException("HiddenItemType");
            }
        }
    }

    public class TraktHiddenItemTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktHiddenItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var itemType = (TraktHiddenItemType)value;
            writer.WriteValue(itemType.AsString());
        }
    }
}
