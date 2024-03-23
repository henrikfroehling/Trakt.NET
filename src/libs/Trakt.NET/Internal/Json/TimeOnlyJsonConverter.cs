using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TraktNET
{
#if NET6_0_OR_GREATER
    internal sealed class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string Format = "HH:mm";

        public override bool CanConvert(Type typeToConvert) => typeof(TimeOnly) == typeToConvert;

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            return string.IsNullOrEmpty(value) ? default : TimeOnly.ParseExact(value, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
#endif
}
