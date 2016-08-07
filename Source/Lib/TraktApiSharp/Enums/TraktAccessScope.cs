namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public sealed class TraktAccessScope : TraktEnumeration
    {
        public static TraktAccessScope Unspecified { get; } = new TraktAccessScope();
        public static TraktAccessScope Public { get; } = new TraktAccessScope(1, "public", "public", "Public");
        public static TraktAccessScope Private { get; } = new TraktAccessScope(2, "private", "private", "Private");
        public static TraktAccessScope Friends { get; } = new TraktAccessScope(4, "friends", "friends", "Friends");

        public TraktAccessScope() : base() { }

        private TraktAccessScope(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        public override IEnumerable<TraktEnumeration> AllEnumerations { get; } = new[] { Unspecified, Public, Private, Friends };
    }

    public class TraktAccessScopeConverter : JsonConverter
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
                return TraktAccessScope.Unspecified;

            return TraktEnumeration.FromObjectName<TraktAccessScope>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var accessScope = (TraktAccessScope)value;
            writer.WriteValue(accessScope.ObjectName);
        }
    }
}
