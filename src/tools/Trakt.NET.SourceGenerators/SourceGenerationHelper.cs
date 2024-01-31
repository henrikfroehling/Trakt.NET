using System.Globalization;
using System.Text;

namespace TraktNET.SourceGenerators
{
    internal static class SourceGenerationHelper
    {
        internal static string GenerateEnumExtensionClass(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Clear();
            stringBuilder.Append(Constants.Header);
            stringBuilder.Append(@"
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Extension methods for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>
");

            stringBuilder.Append(Constants.ExcludeCodeCoverage);
            stringBuilder.Append(@"
    public static partial class ").Append(enumToGenerate.EnumExtensionClassName);
            stringBuilder.Append(@"
    {");

            stringBuilder.Append(@"
        /// <summary>Returns the Json value for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>");
            stringBuilder.Append(@"
        public static string? ToJson(this ").Append(enumToGenerate.Name).Append("? value)");

            stringBuilder.Append(@"
            => value switch
            {");

            foreach (string member in enumToGenerate.Values)
            {
                if (member == "Unspecified")
                {
                    stringBuilder.Append(@"
                ").Append(enumToGenerate.Name).Append('.').Append(member)
                .Append(" => null,");
                }
                else
                {
                    stringBuilder.Append(@"
                ").Append(enumToGenerate.Name).Append('.').Append(member)
                    .Append(" => ").Append('"').Append(member.ToLower(CultureInfo.InvariantCulture)).Append(@""",");
                }
            }

            stringBuilder.Append(@"
                _ => null,");

            stringBuilder.Append(@"
            };");

            stringBuilder.Append(@"

        /// <summary>Returns a <see cref=""").Append(enumToGenerate.Name).Append(@""" /> for the given value, if possible.</summary>");
            stringBuilder.Append(@"
        public static ").Append(enumToGenerate.Name).Append("? To").Append(enumToGenerate.Name).Append("(this string? value)");

            stringBuilder.Append(@"
            => value switch
            {");

            foreach (string member in enumToGenerate.Values)
            {
                stringBuilder.Append(@"
                ").Append($"\"{member.ToLower(CultureInfo.InvariantCulture)}\" => {enumToGenerate.Name}.{member},");

                stringBuilder.Append(@"
                ").Append($"\"{member.ToUpper(CultureInfo.InvariantCulture)}\" => {enumToGenerate.Name}.{member},");

                stringBuilder.Append(@"
                ").Append($"\"{member}\" => {enumToGenerate.Name}.{member},");
            }

            stringBuilder.Append(@"
                _ => null,");

            stringBuilder.Append(@"
            };");

            stringBuilder.Append(@"

        /// <summary>Returns the display name for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>");
            stringBuilder.Append(@"
        public static string DisplayName(this ").Append(enumToGenerate.Name).Append(" value)");

            stringBuilder.Append(@"
            => value switch
            {");

            foreach (string member in enumToGenerate.Values)
            {
                stringBuilder.Append(@"
                ").Append(enumToGenerate.Name).Append('.').Append(member).Append(" => ").Append('"').Append(member).Append(@""",");
            }

            stringBuilder.Append(@"
                _ => value.ToString(),");

            stringBuilder.Append(@"
            };");

            stringBuilder.Append(@"
    }

");
            stringBuilder.Append(Constants.ExcludeCodeCoverage);
            stringBuilder.Append(@"
    public sealed class ").Append(enumToGenerate.Name).Append("JsonConverter : JsonConverter<").Append(enumToGenerate.Name).Append(@"?>
    {");

            stringBuilder.Append(@"
        public override ").Append(enumToGenerate.Name).Append(@"? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string? enumValue = reader.GetString();
                return enumValue.To").Append(enumToGenerate.Name).Append(@"();
            }

            throw new JsonException($""The JSON value could not be converted to {nameof(").Append(enumToGenerate.Name).Append(@")}."");
        }

        public override void Write(Utf8JsonWriter writer, ").Append(enumToGenerate.Name).Append(@"? value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToJson());");

            stringBuilder.Append(@"
    }
}
");

            return stringBuilder.ToString();
        }
    }
}
