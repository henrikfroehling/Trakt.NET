namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktHiddenItemType : TraktEnumeration
    {
        public static TraktHiddenItemType Unspecified { get; } = new TraktHiddenItemType();
        public static TraktHiddenItemType Movie { get; } = new TraktHiddenItemType(1, "movie", "movie", "Movie");
        public static TraktHiddenItemType Show { get; } = new TraktHiddenItemType(2, "show", "show", "Show");
        public static TraktHiddenItemType Season { get; } = new TraktHiddenItemType(4, "season", "season", "Season");

        public TraktHiddenItemType() : base() { }

        private TraktHiddenItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktHiddenItemTypeConverter : JsonConverter
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
                return TraktHiddenItemType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktHiddenItemType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var hiddenItemType = (TraktHiddenItemType)value;
            writer.WriteValue(hiddenItemType.ObjectName);
        }
    }
}
