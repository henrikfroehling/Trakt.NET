namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktSyncItemType : TraktEnumeration
    {
        public static TraktSyncItemType Unspecified { get; } = new TraktSyncItemType();
        public static TraktSyncItemType Movie { get; } = new TraktSyncItemType(1, "movie", "movies", "Movie");
        public static TraktSyncItemType Show { get; } = new TraktSyncItemType(2, "show", "shows", "Show");
        public static TraktSyncItemType Season { get; } = new TraktSyncItemType(4, "season", "seasons", "Season");
        public static TraktSyncItemType Episode { get; } = new TraktSyncItemType(8, "episode", "episodes", "Episode");

        public TraktSyncItemType() : base() { }

        private TraktSyncItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktSyncItemTypeConverter : JsonConverter
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
                return TraktSyncItemType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktSyncItemType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncItemType = (TraktSyncItemType)value;
            writer.WriteValue(syncItemType.ObjectName);
        }
    }
}
