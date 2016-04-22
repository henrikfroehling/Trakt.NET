namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktHiddenItemType
    {
        Unspecified,
        Movie,
        Show,
        Season
    }

    public static class TraktHiddenItemTypeExtensions
    {
        public static string AsString(this TraktHiddenItemType hiddenItemType)
        {
            switch (hiddenItemType)
            {
                case TraktHiddenItemType.Movie: return "movie";
                case TraktHiddenItemType.Show: return "show";
                case TraktHiddenItemType.Season: return "season";
                case TraktHiddenItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(hiddenItemType.ToString());
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
            var hiddenItemType = (TraktHiddenItemType)value;
            writer.WriteValue(hiddenItemType.AsString());
        }
    }
}
