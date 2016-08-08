namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktSyncRatingsItemType : TraktEnumeration
    {
        public static TraktSyncRatingsItemType Unspecified { get; } = new TraktSyncRatingsItemType();
        public static TraktSyncRatingsItemType Movie { get; } = new TraktSyncRatingsItemType(1, "movie", "movies", "Movie");
        public static TraktSyncRatingsItemType Show { get; } = new TraktSyncRatingsItemType(2, "show", "shows", "Show");
        public static TraktSyncRatingsItemType Season { get; } = new TraktSyncRatingsItemType(4, "season", "seasons", "Season");
        public static TraktSyncRatingsItemType Episode { get; } = new TraktSyncRatingsItemType(8, "episode", "episodes", "Episode");
        public static TraktSyncRatingsItemType All { get; } = new TraktSyncRatingsItemType(16, "all", "all", "All");

        public TraktSyncRatingsItemType() : base() { }

        private TraktSyncRatingsItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktSyncRatingsItemTypeConverter : JsonConverter
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
                return TraktSyncRatingsItemType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktSyncRatingsItemType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncRatingsItemType = (TraktSyncRatingsItemType)value;
            writer.WriteValue(syncRatingsItemType.ObjectName);
        }
    }
}
