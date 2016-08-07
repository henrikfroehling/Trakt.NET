namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktListItemType : TraktEnumeration
    {
        public static TraktListItemType Unspecified { get; } = new TraktListItemType();
        public static TraktListItemType Movie { get; } = new TraktListItemType(1, "movie", "movies", "Movie");
        public static TraktListItemType Show { get; } = new TraktListItemType(2, "show", "shows", "Show");
        public static TraktListItemType Season { get; } = new TraktListItemType(4, "season", "seasons", "Season");
        public static TraktListItemType Episode { get; } = new TraktListItemType(8, "episode", "episodes", "Episode");
        public static TraktListItemType Person { get; } = new TraktListItemType(16, "person", "people", "Person");

        public TraktListItemType() : base() { }

        private TraktListItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktListItemTypeConverter : JsonConverter
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
                return TraktListItemType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktListItemType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var listItemType = (TraktListItemType)value;
            writer.WriteValue(listItemType.ObjectName);
        }
    }
}
