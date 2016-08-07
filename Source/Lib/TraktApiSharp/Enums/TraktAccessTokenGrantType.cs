namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktAccessTokenGrantType : TraktEnumeration
    {
        public static TraktAccessTokenGrantType Unspecified { get; } = new TraktAccessTokenGrantType();
        public static TraktAccessTokenGrantType AuthorizationCode { get; } = new TraktAccessTokenGrantType(1, "authorization_code", "authorization_code", "Authorization Code");
        public static TraktAccessTokenGrantType RefreshToken { get; } = new TraktAccessTokenGrantType(2, "refresh_token", "refresh_token", "Refresh Token");

        public TraktAccessTokenGrantType() : base() { }

        private TraktAccessTokenGrantType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktAccessTokenGrantTypeConverter : JsonConverter
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
                return TraktAccessTokenGrantType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktAccessTokenGrantType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var accessTokenGrantType = (TraktAccessTokenGrantType)value;
            writer.WriteValue(accessTokenGrantType.ObjectName);
        }
    }
}
