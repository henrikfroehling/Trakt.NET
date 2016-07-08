namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktUserLikeType
    {
        Unspecified,
        Comment,
        List
    }

    public static class TraktUserLikeTypeExtensions
    {
        public static string AsString(this TraktUserLikeType userLikeType)
        {
            switch (userLikeType)
            {
                case TraktUserLikeType.Comment: return "comment";
                case TraktUserLikeType.List: return "list";
                case TraktUserLikeType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(userLikeType.ToString());
            }
        }

        public static string AsStringUriParameter(this TraktUserLikeType userLikeType)
        {
            switch (userLikeType)
            {
                case TraktUserLikeType.Comment: return "comments";
                case TraktUserLikeType.List: return "lists";
                case TraktUserLikeType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(userLikeType.ToString());
            }
        }
    }

    public class TraktUserLikeTypeConverter : JsonConverter
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
                return TraktUserLikeType.Unspecified;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktUserLikeType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var userLikeType = (TraktUserLikeType)value;
            writer.WriteValue(userLikeType.AsString());
        }
    }
}
