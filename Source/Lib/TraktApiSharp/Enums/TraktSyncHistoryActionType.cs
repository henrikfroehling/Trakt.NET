namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktSyncHistoryActionType
    {
        Unspecified,
        Scrobble,
        Checkin,
        Watch
    }

    public static class TraktSyncHistoryActionTypeExtensions
    {
        public static string AsString(this TraktSyncHistoryActionType syncHistoryActionType)
        {
            switch (syncHistoryActionType)
            {
                case TraktSyncHistoryActionType.Unspecified: return string.Empty;
                case TraktSyncHistoryActionType.Scrobble: return "scrobble";
                case TraktSyncHistoryActionType.Checkin: return "checkin";
                case TraktSyncHistoryActionType.Watch: return "watch";
                default:
                    throw new NotSupportedException(syncHistoryActionType.ToString());
            }
        }
    }

    public class TraktSyncHistoryActionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (enumString.Equals(TraktSyncHistoryActionType.Unspecified.AsString()))
                return TraktSyncHistoryActionType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktSyncHistoryActionType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncHistoryActionType = (TraktSyncHistoryActionType)value;
            writer.WriteValue(syncHistoryActionType.AsString());
        }
    }
}
