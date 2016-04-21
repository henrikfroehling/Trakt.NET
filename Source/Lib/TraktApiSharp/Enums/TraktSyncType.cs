namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncType
    {
        Unspecified,
        Movie,
        Episode
    }

    public static class TraktSyncTypeExtensions
    {
        public static string AsString(this TraktSyncType syncType)
        {
            switch (syncType)
            {
                case TraktSyncType.Movie: return "movie";
                case TraktSyncType.Episode: return "episode";
                case TraktSyncType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktSyncType syncProgressType)
        {
            switch (syncProgressType)
            {
                case TraktSyncType.Movie: return "movies";
                case TraktSyncType.Episode: return "episodes";
                case TraktSyncType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncProgressType.ToString());
            }
        }
    }

    public class TraktSyncTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktSyncType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncType = (TraktSyncType)value;
            writer.WriteValue(syncType.AsString());
        }
    }
}
