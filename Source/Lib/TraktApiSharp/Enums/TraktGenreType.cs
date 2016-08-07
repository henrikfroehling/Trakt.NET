namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public sealed class TraktGenreType : TraktEnumeration
    {
        public static TraktGenreType Unspecified { get; } = new TraktGenreType();
        public static TraktGenreType Shows { get; } = new TraktGenreType(1, "shows", "shows", "Shows");
        public static TraktGenreType Movies { get; } = new TraktGenreType(2, "movies", "movies", "Movies");

        public TraktGenreType() : base() { }

        private TraktGenreType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        public override IEnumerable<TraktEnumeration> AllEnumerations { get; } = new[] { Unspecified, Shows, Movies };
    }

    public class TraktGenreTypeConverter : JsonConverter
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
                return TraktGenreType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktGenreType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var genreType = (TraktGenreType)value;
            writer.WriteValue(genreType.ObjectName);
        }
    }
}
