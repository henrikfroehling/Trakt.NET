namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktHistoryActionType
    {
        Unspecified,
        Scrobble,
        Checkin,
        Watch
    }

    public static class TraktHistoryActionTypeExtensions
    {
        public static string AsString(this TraktHistoryActionType historyActionType)
        {
            switch (historyActionType)
            {
                case TraktHistoryActionType.Unspecified: return string.Empty;
                case TraktHistoryActionType.Scrobble: return "scrobble";
                case TraktHistoryActionType.Checkin: return "checkin";
                case TraktHistoryActionType.Watch: return "watch";
                default:
                    throw new NotSupportedException(historyActionType.ToString());
            }
        }
    }

    public class TraktHistoryActionTypeConverter : JsonConverter
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

            if (enumString.Equals(TraktHistoryActionType.Unspecified.AsString()))
                return TraktHistoryActionType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktHistoryActionType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var historyActionType = (TraktHistoryActionType)value;
            writer.WriteValue(historyActionType.AsString());
        }
    }
}
