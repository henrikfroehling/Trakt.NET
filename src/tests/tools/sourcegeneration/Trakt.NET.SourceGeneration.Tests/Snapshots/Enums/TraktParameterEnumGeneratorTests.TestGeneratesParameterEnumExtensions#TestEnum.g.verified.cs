﻿//-----------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Trakt.NET source generator.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------------------------------

#nullable enable

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SourceGeneraterTestNamespace
{
    /// <summary>Extension methods for <see cref="TestEnum" />.</summary>
    public static partial class TestEnumExtensions
    {
        /// <summary>Returns the Json value for <see cref="TestEnum" />.</summary>
        public static string? ToJson(this TestEnum value)
            => value switch
            {
                TestEnum.Unspecified => null,
                TestEnum.ValueOne => "value_one",
                TestEnum.ValueTwo => "value_two",
                _ => null,
            };

        /// <summary>Returns a <see cref="TestEnum" /> for the given value, if possible.</summary>
        public static TestEnum ToTestEnum(this string? value)
            => value switch
            {
                "unspecified" => TestEnum.Unspecified,
                "value_one" => TestEnum.ValueOne,
                "value_two" => TestEnum.ValueTwo,
                _ => TestEnum.Unspecified,
            };

        /// <summary>Returns the display name for <see cref="TestEnum" />.</summary>
        public static string DisplayName(this TestEnum value)
            => value switch
            {
                TestEnum.Unspecified => "Unspecified",
                TestEnum.ValueOne => "Value One",
                TestEnum.ValueTwo => "Value Two",
                _ => value.ToString(),
            };

        /// <summary>Converts a <see cref="TestEnum" /> to a valid URI path value.</summary>
        public static string ToUriPath(this TestEnum value)
        {
            if (value == TestEnum.Unspecified)
            {
                return string.Empty;
            }

            return "testenum=" + value.ToJson();
        }
    }

    /// <summary>JSON converter for <see cref="TestEnum" />.</summary>
    public sealed class TestEnumJsonConverter : JsonConverter<TestEnum>
    {
        public override bool CanConvert(Type typeToConvert) => typeof(TestEnum) == typeToConvert;

        public override TestEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? enumValue = reader.GetString();
            return string.IsNullOrEmpty(enumValue) ? default : enumValue.ToTestEnum();
        }

        public override void Write(Utf8JsonWriter writer, TestEnum value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToJson());
    }
}