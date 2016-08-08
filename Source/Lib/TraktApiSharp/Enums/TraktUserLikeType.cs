namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktUserLikeType : TraktEnumeration
    {
        public static TraktUserLikeType Unspecified { get; } = new TraktUserLikeType();
        public static TraktUserLikeType Comment { get; } = new TraktUserLikeType(1, "comment", "comments", "Comment");
        public static TraktUserLikeType List { get; } = new TraktUserLikeType(2, "list", "lists", "List");

        public TraktUserLikeType() : base() { }

        private TraktUserLikeType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
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

            return TraktEnumeration.FromObjectName<TraktUserLikeType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var userLikeType = (TraktUserLikeType)value;
            writer.WriteValue(userLikeType.ObjectName);
        }
    }
}
