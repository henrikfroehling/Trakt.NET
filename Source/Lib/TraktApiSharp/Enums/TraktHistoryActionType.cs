namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktHistoryActionType : TraktEnumeration
    {
        public static TraktHistoryActionType Unspecified { get; } = new TraktHistoryActionType();
        public static TraktHistoryActionType Scrobble { get; } = new TraktHistoryActionType(1, "scrobble", "scrobble", "Scrobble");
        public static TraktHistoryActionType Checkin { get; } = new TraktHistoryActionType(2, "checkin", "checkin", "Checkin");
        public static TraktHistoryActionType Watch { get; } = new TraktHistoryActionType(4, "watch", "watch", "Watch");

        public TraktHistoryActionType() : base() { }

        private TraktHistoryActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
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

            if (string.IsNullOrEmpty(enumString))
                return TraktHistoryActionType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktHistoryActionType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var historyActionType = (TraktHistoryActionType)value;
            writer.WriteValue(historyActionType.ObjectName);
        }
    }
}
