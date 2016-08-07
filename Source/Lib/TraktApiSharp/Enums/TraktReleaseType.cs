namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktReleaseType : TraktEnumeration
    {
        public static TraktReleaseType Unspecified { get; } = new TraktReleaseType();
        public static TraktReleaseType Unknown { get; } = new TraktReleaseType(1, "unknown", "unknown", "Unknown");
        public static TraktReleaseType Premiere { get; } = new TraktReleaseType(2, "premiere", "premiere", "Premiere");
        public static TraktReleaseType Limited { get; } = new TraktReleaseType(4, "limited", "limited", "Limited");
        public static TraktReleaseType Theatrical { get; } = new TraktReleaseType(8, "theatrical", "theatrical", "Theatrical");
        public static TraktReleaseType Digital { get; } = new TraktReleaseType(16, "digital", "digital", "Digital");
        public static TraktReleaseType Physical { get; } = new TraktReleaseType(32, "physical", "physical", "Physical");
        public static TraktReleaseType TV { get; } = new TraktReleaseType(64, "tv", "tv", "TV");

        public TraktReleaseType() : base() { }

        private TraktReleaseType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktReleaseTypeConverter : JsonConverter
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
                return TraktReleaseType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktReleaseType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var releaseType = (TraktReleaseType)value;
            writer.WriteValue(releaseType.ObjectName);
        }
    }
}
