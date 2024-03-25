using System.Text;

namespace TraktNET.SourceGenerators.Enums
{
    internal sealed class TraktEnumExtensionsSourceWriter
    {
        private const string UnspecifiedValue = "Unspecified";
        private const string NoneValue = "None";

        private static readonly IReadOnlyList<string> Usings = [
            "System.Text.Json",
            "System.Text.Json.Serialization"
        ];

        private static bool _hasUnspecifiedMember;
        private static bool _hasNoneMember;
        private static string _invalidValueMember = string.Empty;

        internal static string Write(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            CheckInvalidEnumMember(enumToGenerate);

            stringBuilder.Clear();

            WriteHeaderAndUsings(stringBuilder);
            WriteNamespaceBegin(stringBuilder);
            WriteEnumExtensionsClass(stringBuilder, enumToGenerate);
            WriteJsonConverterClass(stringBuilder, enumToGenerate);
            WriteNamespaceEnd(stringBuilder);

            return stringBuilder.ToString();
        }

        private static void CheckInvalidEnumMember(in TraktEnumToGenerate enumToGenerate)
        {
            _hasUnspecifiedMember = enumToGenerate.Values.Any(m => m.Name == UnspecifiedValue);
            _hasNoneMember = enumToGenerate.Values.Any(m => m.Name == NoneValue);

            if (_hasUnspecifiedMember)
                _invalidValueMember = UnspecifiedValue;
            else if (_hasNoneMember)
                _invalidValueMember = NoneValue;
        }

        private static void WriteHeaderAndUsings(StringBuilder stringBuilder)
        {
            stringBuilder.Append(Constants.Header);

            foreach (string @using in Usings)
            {
                stringBuilder.Append(@"
using ").Append(@using).Append(';');
            }

            stringBuilder.Append(@"
");
        }

        private static void WriteNamespaceBegin(StringBuilder stringBuilder)
            => stringBuilder.Append(@"
namespace TraktNET
{");

        private static void WriteEnumExtensionsClass(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            WriteExtensionsClassBegin(stringBuilder, enumToGenerate);

            WriteToJsonMethod(stringBuilder, enumToGenerate);
            WriteJsonToEnumMethod(stringBuilder, enumToGenerate);
            WriteDisplayNameMethod(stringBuilder, enumToGenerate);

            if (enumToGenerate.HasFlagsAttribute)
                WriteHasFlagSetMethod(stringBuilder, enumToGenerate);

            if (enumToGenerate.HasParameterEnumAttribute)
                WriteToUriPathMethod(stringBuilder, enumToGenerate);

            WriteExtensionsClassEnd(stringBuilder);
        }

        private static void WriteExtensionsClassBegin(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
            => stringBuilder.Append(@"
    /// <summary>Extension methods for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>
").Append(Constants.ExcludeCodeCoverage).Append(@"
    public static partial class ").Append(enumToGenerate.EnumExtensionClassName).Append(@"
    {");

        private static void WriteToJsonMethod(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Append(@"
        /// <summary>Returns the Json value for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>").Append(@"
        public static string? ToJson(this ").Append(enumToGenerate.Name).Append(" value)").Append(@"
            => value switch
            {");

            string enumName = enumToGenerate.Name;

            foreach (TraktEnumMemberToGenerate member in enumToGenerate.Values)
            {
                string memberName = member.Name;

                if ((memberName == UnspecifiedValue || memberName == NoneValue) && !member.HasTraktEnumMemberAttribute)
                    WriteToJsonSwitchInvalidValue(stringBuilder, enumName, memberName);
                else if (member.HasTraktEnumMemberAttribute && member.JsonValue != null)
                    WriteToJsonSwitchCase(stringBuilder, enumName, memberName, member.JsonValue);
                else
                    WriteToJsonSwitchCase(stringBuilder, enumName, memberName, memberName.ToLowercaseNamingConvention());
            }

            stringBuilder.Append(@"
                _ => null,").Append(@"
            };");
        }

        private static void WriteToJsonSwitchCase(StringBuilder stringBuilder, string enumName, string memberName, string jsonValue)
            => stringBuilder.Append(@"
                ").Append(enumName).Append('.').Append(memberName).Append(" => ").Append('"').Append(jsonValue).Append(@""",");

        private static void WriteToJsonSwitchInvalidValue(StringBuilder stringBuilder, string enumName, string memberName)
            => stringBuilder.Append(@"
                ").Append(enumName).Append('.').Append(memberName).Append(" => null,");

        private static void WriteJsonToEnumMethod(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Append(@"

        /// <summary>Returns a <see cref=""").Append(enumToGenerate.Name).Append(@""" /> for the given value, if possible.</summary>").Append(@"
        public static ").Append(enumToGenerate.Name).Append(" To").Append(enumToGenerate.Name).Append("(this string? value)").Append(@"
            => value switch
            {");

            string enumName = enumToGenerate.Name;

            foreach (TraktEnumMemberToGenerate member in enumToGenerate.Values)
            {
                string memberName = member.Name;

                if (member.HasTraktEnumMemberAttribute && member.JsonValue != null)
                    WriteFromJsonSwitchCase(stringBuilder, enumName, memberName, member.JsonValue);
                else
                    WriteFromJsonSwitchCase(stringBuilder, enumName, memberName, memberName.ToLowercaseNamingConvention());
            }

            if (_hasUnspecifiedMember)
                WriteFromJsonSwitchDefault(stringBuilder, enumName, UnspecifiedValue);
            else if (_hasNoneMember)
                WriteFromJsonSwitchDefault(stringBuilder, enumName, NoneValue);

            stringBuilder.Append(@"
            };");
        }

        private static void WriteFromJsonSwitchCase(StringBuilder stringBuilder, string enumName, string memberName, string jsonValue)
            => stringBuilder.Append(@"
                ").Append($"\"{jsonValue}\" => {enumName}.{memberName},");

        private static void WriteFromJsonSwitchDefault(StringBuilder stringBuilder, string enumName, string value)
            => stringBuilder.Append(@"
                _ => ").Append(enumName).Append('.').Append(value).Append(',');

        private static void WriteDisplayNameMethod(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Append(@"

        /// <summary>Returns the display name for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>").Append(@"
        public static string DisplayName(this ").Append(enumToGenerate.Name).Append(" value)");

            if (enumToGenerate.HasFlagsAttribute)
            {
                WriteDisplayNameMethodForEnumWithFlags(stringBuilder, enumToGenerate);
            }
            else
            {
                stringBuilder.Append(@"
            => value switch
            {");

                string enumName = enumToGenerate.Name;

                foreach (TraktEnumMemberToGenerate member in enumToGenerate.Values)
                {
                    string memberName = member.Name;

                    if (member.HasTraktEnumMemberAttribute && !string.IsNullOrWhiteSpace(member.DisplayName))
                        WriteDisplayNameSwitchCase(stringBuilder, enumName, memberName, member.DisplayName);
                    else
                        WriteDisplayNameSwitchCase(stringBuilder, enumName, memberName, memberName.ToDisplayName());
                }

                stringBuilder.Append(@"
                _ => value.ToString(),").Append(@"
            };");
            }
        }

        private static void WriteDisplayNameSwitchCase(StringBuilder stringBuilder, string enumName, string memberName, string displayName)
            => stringBuilder.Append(@"
                ").Append(enumName).Append('.').Append(memberName).Append(" => ").Append('"').Append(displayName).Append(@""",");

        private static void WriteDisplayNameMethodForEnumWithFlags(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Append(@"
        {").Append(@"
            var values = new List<string>();");

            string enumName = enumToGenerate.Name;

            foreach (TraktEnumMemberToGenerate member in enumToGenerate.Values)
            {
                string memberName = member.Name;

                if (memberName == _invalidValueMember)
                {
                    if (member.HasTraktEnumMemberAttribute && !string.IsNullOrWhiteSpace(member.DisplayName))
                        WriteFlagDisplayNameValuesAdd(stringBuilder, enumName, memberName, member.DisplayName);
                    else
                        WriteFlagDisplayNameValuesAdd(stringBuilder, enumName, memberName, memberName.ToDisplayName());
                }
                else
                {
                    if (member.HasTraktEnumMemberAttribute && !string.IsNullOrWhiteSpace(member.DisplayName))
                        WriteFlagDisplayNameValuesAddWithFlagCheck(stringBuilder, enumName, memberName, member.DisplayName);
                    else
                        WriteFlagDisplayNameValuesAddWithFlagCheck(stringBuilder, enumName, memberName, memberName.ToDisplayName());
                }
            }

            stringBuilder.Append(@"

            return string.Join("", "", values);
        }");
        }

        private static void WriteFlagDisplayNameValuesAdd(StringBuilder stringBuilder, string enumName, string memberName, string displayName)
            => stringBuilder.Append(@"

            if (value == ").Append(enumName).Append('.').Append(memberName).Append(@")
                values.Add(""").Append(displayName).Append(@""");");

        private static void WriteFlagDisplayNameValuesAddWithFlagCheck(StringBuilder stringBuilder, string enumName, string memberName, string displayName)
            => stringBuilder.Append(@"

            if (value.HasFlagSet(").Append(enumName).Append('.').Append(memberName).Append(@"))
                values.Add(""").Append(displayName).Append(@""");");

        private static void WriteHasFlagSetMethod(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
            => stringBuilder.Append(@"

        /// <summary>Determines whether one or more bit fields are set in <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>
        public static bool HasFlagSet(this ").Append(enumToGenerate.Name).Append(" value, ").Append(enumToGenerate.Name).Append(@" flag)
            => flag == 0 ? true : (value & flag) == flag;");

        private static void WriteToUriPathMethod(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
        {
            stringBuilder.Append(@"

        /// <summary>Converts a <see cref=""").Append(enumToGenerate.Name).Append(@""" /> to a valid URI path value.</summary>
        public static string ToUriPath(this ").Append(enumToGenerate.Name).Append(@" value)
        {");

            if (_hasUnspecifiedMember || _hasNoneMember)
            {
                stringBuilder.Append(@"
            if (value == ").Append(enumToGenerate.Name).Append('.').Append(_invalidValueMember).Append(@")
                return string.Empty;
");
            }

            if (enumToGenerate.HasFlagsAttribute)
            {
                stringBuilder.Append(@"
            var values = new List<string>();");

                foreach (TraktEnumMemberToGenerate member in enumToGenerate.Values)
                {
                    if (member.Name == _invalidValueMember)
                        continue;

                    WriteToUriPathValueAdd(stringBuilder, enumToGenerate.Name, member.Name);
                }

                WriteToUriPathReturn(stringBuilder, true, enumToGenerate.ParameterEnumAttributeValue, @"string.Join("","", values);");
            }
            else
            {
                WriteToUriPathReturn(stringBuilder, false, enumToGenerate.ParameterEnumAttributeValue, "value.ToJson();");
            }

            stringBuilder.Append(@"
        }");
        }

        private static void WriteToUriPathValueAdd(StringBuilder stringBuilder, string enumName, string memberName)
            => stringBuilder.Append(@"

            if (value.HasFlagSet(").Append(enumName).Append('.').Append(memberName).Append(@"))
                values.Add(").Append(enumName).Append('.').Append(memberName).Append(@".ToJson()!);");

        private static void WriteToUriPathReturn(StringBuilder stringBuilder, bool needsEmptyLine, string parameterEnumValue, string joinValues)
        {
            if (needsEmptyLine)
            {
                stringBuilder.Append(@"

            return ");
            }
            else
            {
                stringBuilder.Append(@"
            return ");
            }

            if (!string.IsNullOrWhiteSpace(parameterEnumValue))
                stringBuilder.Append('"').Append(parameterEnumValue).Append(@"="" + ");

            stringBuilder.Append(joinValues);
        }

        private static void WriteExtensionsClassEnd(StringBuilder stringBuilder)
            => stringBuilder.Append(@"
    }
");

        private static void WriteJsonConverterClass(StringBuilder stringBuilder, in TraktEnumToGenerate enumToGenerate)
            => stringBuilder.Append(@"
    /// <summary>JSON converter for <see cref=""").Append(enumToGenerate.Name).Append(@""" />.</summary>
").Append(Constants.ExcludeCodeCoverage).Append(@"
    public sealed class ").Append(enumToGenerate.Name).Append("JsonConverter : JsonConverter<").Append(enumToGenerate.Name).Append(@">
    {").Append(@"
        public override bool CanConvert(Type typeToConvert) => typeof(").Append(enumToGenerate.Name).Append(@") == typeToConvert;

        public override ").Append(enumToGenerate.Name).Append(@" Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? enumValue = reader.GetString();
            return string.IsNullOrEmpty(enumValue) ? default : enumValue.To").Append(enumToGenerate.Name).Append(@"();
        }

        public override void Write(Utf8JsonWriter writer, ").Append(enumToGenerate.Name).Append(@" value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToJson());
    }");

        private static void WriteNamespaceEnd(StringBuilder stringBuilder)
            => stringBuilder.Append(@"
}
");
    }
}
