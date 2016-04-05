namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktAccessScope
    {
        Public,
        Private,
        Friends
    }

    internal static class TraktAccessScopeExtensions
    {
        internal static string AsString(this TraktAccessScope scope)
        {
            switch (scope)
            {
                case TraktAccessScope.Public: return "public";
                case TraktAccessScope.Private: return "private";
                case TraktAccessScope.Friends: return "friends";
                default:
                    throw new ArgumentOutOfRangeException("AccessScope");
            }
        }
    }

    public class TraktAccessScopeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktAccessScope), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var accessScope = (TraktAccessScope)value;
            writer.WriteValue(accessScope.AsString());
        }
    }
}
