namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncRatingsItemType
    {
        Unspecified,
        Movie,
        Show,
        Season,
        Episode,
        All
    }

    public static class TraktSyncRatingsItemTypeExtensions
    {
        public static string AsString(this TraktSyncRatingsItemType syncRatingsItemType)
        {
            switch (syncRatingsItemType)
            {
                case TraktSyncRatingsItemType.Movie: return "movie";
                case TraktSyncRatingsItemType.Show: return "show";
                case TraktSyncRatingsItemType.Season: return "season";
                case TraktSyncRatingsItemType.Episode: return "episode";
                case TraktSyncRatingsItemType.All: return "all";
                case TraktSyncRatingsItemType.Unspecified:
                    return string.Empty;
                default:
                    throw new NotSupportedException(syncRatingsItemType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktSyncRatingsItemType syncRatingsItemType)
        {
            switch (syncRatingsItemType)
            {
                case TraktSyncRatingsItemType.Movie: return "movies";
                case TraktSyncRatingsItemType.Show: return "shows";
                case TraktSyncRatingsItemType.Season: return "seasons";
                case TraktSyncRatingsItemType.Episode: return "episodes";
                case TraktSyncRatingsItemType.All: return "all";
                case TraktSyncRatingsItemType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(syncRatingsItemType.ToString());
            }
        }
    }

    public class TraktSyncRatingsItemTypeConverter : JsonConverter
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
                return TraktSyncRatingsItemType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncRatingsItemType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncRatingsItemType = (TraktSyncRatingsItemType)value;
            writer.WriteValue(syncRatingsItemType.AsString());
        }
    }
}
