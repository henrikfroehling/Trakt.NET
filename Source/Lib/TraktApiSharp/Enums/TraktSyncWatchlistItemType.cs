namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncWatchlistItemType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode
    }

    public static class TraktSyncWatchlistItemTypeExtensions
    {
        public static string AsString(this TraktSyncWatchlistItemType syncWatchlistItemType)
        {
            switch (syncWatchlistItemType)
            {
                case TraktSyncWatchlistItemType.Movie: return "movie";
                case TraktSyncWatchlistItemType.Show: return "show";
                case TraktSyncWatchlistItemType.Season: return "season";
                case TraktSyncWatchlistItemType.Episode: return "episode";
                case TraktSyncWatchlistItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncWatchlistItemType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktSyncWatchlistItemType syncWatchlistItemType)
        {
            switch (syncWatchlistItemType)
            {
                case TraktSyncWatchlistItemType.Movie: return "movies";
                case TraktSyncWatchlistItemType.Show: return "shows";
                case TraktSyncWatchlistItemType.Season: return "seasons";
                case TraktSyncWatchlistItemType.Episode: return "episodes";
                case TraktSyncWatchlistItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncWatchlistItemType.ToString());
            }
        }
    }

    public class TraktSyncWatchlistItemTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktSyncWatchlistItemType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncWatchlistItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncWatchlistItemType = (TraktSyncWatchlistItemType)value;
            writer.WriteValue(syncWatchlistItemType.AsString());
        }
    }
}
