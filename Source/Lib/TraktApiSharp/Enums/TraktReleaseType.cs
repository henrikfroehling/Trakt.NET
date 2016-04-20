namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktReleaseType
    {
        Unknown,
        Premiere,
        Limited,
        Theatrical,
        Digital,
        Physical,
        Tv
    }

    public static class TraktReleaseTypeExtensions
    {
        public static string AsString(this TraktReleaseType releaseType)
        {
            switch (releaseType)
            {
                case TraktReleaseType.Unknown: return "unknown";
                case TraktReleaseType.Premiere: return "premiere";
                case TraktReleaseType.Limited: return "limited";
                case TraktReleaseType.Theatrical: return "theatrical";
                case TraktReleaseType.Digital: return "digital";
                case TraktReleaseType.Physical: return "physical";
                case TraktReleaseType.Tv: return "tv";
                default:
                    throw new NotSupportedException(releaseType.ToString());
            }
        }
    }

    public class TraktReleaseTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktReleaseType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var releaseType = (TraktReleaseType)value;
            writer.WriteValue(releaseType.AsString());
        }
    }
}
