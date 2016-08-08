namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktShowStatus : TraktEnumeration
    {
        public static TraktShowStatus Unspecified { get; } = new TraktShowStatus();
        public static TraktShowStatus ReturningSeries { get; } = new TraktShowStatus(1, "returning series", "returning series", "Returning Series");
        public static TraktShowStatus InProduction { get; } = new TraktShowStatus(2, "in production", "in production", "In Production");
        public static TraktShowStatus Canceled { get; } = new TraktShowStatus(4, "canceled", "canceled", "Canceled");
        public static TraktShowStatus Ended { get; } = new TraktShowStatus(8, "ended", "ended", "Ended");

        public TraktShowStatus() : base() { }

        private TraktShowStatus(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktShowStatusConverter : JsonConverter
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
                return TraktShowStatus.Unspecified;

            return TraktEnumeration.FromObjectName<TraktShowStatus>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var showStatus = (TraktShowStatus)value;
            writer.WriteValue(showStatus.ObjectName);
        }
    }
}
