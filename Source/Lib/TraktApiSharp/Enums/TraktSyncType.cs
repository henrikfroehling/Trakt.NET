namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktSyncType : TraktEnumeration
    {
        public static TraktSyncType Unspecified { get; } = new TraktSyncType();
        public static TraktSyncType Movie { get; } = new TraktSyncType(1, "movie", "movies", "Movie");
        public static TraktSyncType Episode { get; } = new TraktSyncType(2, "episode", "episodes", "Episode");

        public TraktSyncType() : base() { }

        private TraktSyncType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktSyncTypeConverter : JsonConverter
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
                return TraktSyncType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktSyncType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var syncType = (TraktSyncType)value;
            writer.WriteValue(syncType.ObjectName);
        }
    }
}
