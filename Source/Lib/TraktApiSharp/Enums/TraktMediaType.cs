namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktMediaType : TraktEnumeration
    {
        public static TraktMediaType Unspecified { get; } = new TraktMediaType();
        public static TraktMediaType Digital { get; } = new TraktMediaType(1, "digital", "digital", "Digital");
        public static TraktMediaType Bluray { get; } = new TraktMediaType(2, "bluray", "bluray", "Bluray");
        public static TraktMediaType HD_DVD { get; } = new TraktMediaType(4, "hddvd", "hddvd", "HD DVD");
        public static TraktMediaType DVD { get; } = new TraktMediaType(8, "dvd", "dvd", "DVD");
        public static TraktMediaType VCD { get; } = new TraktMediaType(16, "vcd", "vcd", "VCD");
        public static TraktMediaType VHS { get; } = new TraktMediaType(32, "vhs", "vhs", "VHS");
        public static TraktMediaType BetaMax { get; } = new TraktMediaType(64, "betamax", "betamax", "BetaMax");
        public static TraktMediaType LaserDisc { get; } = new TraktMediaType(128, "laserdisc", "laserdisc", "LaserDisc");

        public TraktMediaType() : base() { }

        private TraktMediaType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktMediaTypeConverter : JsonConverter
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
                return TraktMediaType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktMediaType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaType = (TraktMediaType)value;
            writer.WriteValue(mediaType.ObjectName);
        }
    }
}
