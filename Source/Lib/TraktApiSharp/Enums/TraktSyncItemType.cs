namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncItemType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode
    }

    public static class TraktSyncItemTypeExtensions
    {
        public static string AsString(this TraktSyncItemType syncItemType)
        {
            switch (syncItemType)
            {
                case TraktSyncItemType.Movie: return "movie";
                case TraktSyncItemType.Show: return "show";
                case TraktSyncItemType.Season: return "season";
                case TraktSyncItemType.Episode: return "episode";
                case TraktSyncItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncItemType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktSyncItemType syncItemType)
        {
            switch (syncItemType)
            {
                case TraktSyncItemType.Movie: return "movies";
                case TraktSyncItemType.Show: return "shows";
                case TraktSyncItemType.Season: return "seasons";
                case TraktSyncItemType.Episode: return "episodes";
                case TraktSyncItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncItemType.ToString());
            }
        }
    }

    public class TraktSyncItemTypeConverter : JsonConverter
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
                return TraktSyncItemType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncItemType = (TraktSyncItemType)value;
            writer.WriteValue(syncItemType.AsString());
        }
    }
}
