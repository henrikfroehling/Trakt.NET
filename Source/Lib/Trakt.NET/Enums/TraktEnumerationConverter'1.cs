namespace TraktNet.Enums
{
    using Newtonsoft.Json;
    using System;

    public class TraktEnumerationConverter<T> : JsonConverter where T : TraktEnumeration, new()
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return Activator.CreateInstance(typeof(T));

            return TraktEnumeration.FromObjectName<T>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumeration = (T)value;
            writer.WriteValue(enumeration.ObjectName);
        }
    }
}
