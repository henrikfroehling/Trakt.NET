namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktAccessTokenType
    {
        Bearer
    }

    public static class TraktAccessTokenTypeExtensions
    {
        public static string AsString(this TraktAccessTokenType scope)
        {
            switch (scope)
            {
                case TraktAccessTokenType.Bearer: return "bearer";
                default:
                    throw new ArgumentOutOfRangeException("AccessTokenType");
            }
        }
    }

    public class TraktAccessTokenTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktAccessTokenType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var tokenType = (TraktAccessTokenType)value;
            writer.WriteValue(tokenType.AsString());
        }
    }
}
