namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktAccessTokenGrantType
    {
        AuthorizationCode,
        RefreshToken,
        Unspecified
    }

    public static class TraktAccessTokenGrantTypeExtensions
    {
        public static string AsString(this TraktAccessTokenGrantType scope)
        {
            switch (scope)
            {
                case TraktAccessTokenGrantType.AuthorizationCode: return "authorization_code";
                case TraktAccessTokenGrantType.RefreshToken: return "refresh_token";
                case TraktAccessTokenGrantType.Unspecified: return "";
                default:
                    throw new ArgumentOutOfRangeException("AccessTokenGrantType");
            }
        }
    }

    public class TraktAccessTokenGrantTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.ToLower();

            if (enumString.Equals(TraktAccessTokenGrantType.AuthorizationCode.AsString()))
                return TraktAccessTokenGrantType.AuthorizationCode;
            else if (enumString.Equals(TraktAccessTokenGrantType.RefreshToken.AsString()))
                return TraktAccessTokenGrantType.RefreshToken;

            return TraktAccessTokenGrantType.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var grantType = (TraktAccessTokenGrantType)value;
            writer.WriteValue(grantType.AsString());
        }
    }
}
