namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncHistoryItemType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode
    }

    public static class TraktSyncHistoryItemTypeExtensions
    {
        public static string AsString(this TraktSyncHistoryItemType syncHistoryItemType)
        {
            switch (syncHistoryItemType)
            {
                case TraktSyncHistoryItemType.Movie: return "movie";
                case TraktSyncHistoryItemType.Show: return "show";
                case TraktSyncHistoryItemType.Season: return "season";
                case TraktSyncHistoryItemType.Episode: return "episode";
                case TraktSyncHistoryItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncHistoryItemType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktSyncHistoryItemType syncHistoryItemType)
        {
            switch (syncHistoryItemType)
            {
                case TraktSyncHistoryItemType.Movie: return "movies";
                case TraktSyncHistoryItemType.Show: return "shows";
                case TraktSyncHistoryItemType.Season: return "seasons";
                case TraktSyncHistoryItemType.Episode: return "episodes";
                case TraktSyncHistoryItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncHistoryItemType.ToString());
            }
        }
    }

    public class TraktSyncHistoryItemTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktSyncHistoryItemType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncHistoryItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncHistoryItemType = (TraktSyncHistoryItemType)value;
            writer.WriteValue(syncHistoryItemType.AsString());
        }
    }
}
