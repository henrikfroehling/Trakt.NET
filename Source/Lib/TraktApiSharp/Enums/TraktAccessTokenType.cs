namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktAccessTokenType : TraktEnumeration
    {
        public static TraktAccessTokenType Unspecified { get; } = new TraktAccessTokenType();
        public static TraktAccessTokenType Bearer { get; } = new TraktAccessTokenType(1, "bearer", "bearer", "Bearer");

        public TraktAccessTokenType() : base() { }

        private TraktAccessTokenType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktAccessTokenTypeConverter : JsonConverter
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
                return TraktAccessTokenType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktAccessTokenType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var accessTokenType = (TraktAccessTokenType)value;
            writer.WriteValue(accessTokenType.ObjectName);
        }
    }
}
