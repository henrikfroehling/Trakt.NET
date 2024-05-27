using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Enums
{
    internal sealed class EnumSourceEmitter(SourceProductionContext context) : SourceEmitter<EnumGenerationSpecification>(context)
    {
        private const string UnspecifiedValue = "Unspecified";
        private const string NoneValue = "None";

        private static readonly IReadOnlyList<string> Usings = [
            "System.Text.Json",
            "System.Text.Json.Serialization"
        ];

        private string _enumName = string.Empty;
        private string _enumExtensionsName = string.Empty;
        private string _enumNamespace = string.Empty;
        private bool _hasFlagsAttribute;
        private bool _hasTraktParameterEnumAttribute;
        private string _traktParameterEnumAttributeValue = string.Empty;
        private List<EnumMemberGenerationSpecification> _enumMembers = [];
        private static bool _hasUnspecifiedMember;
        private static bool _hasNoneMember;
        private static string _invalidValueMember = string.Empty;

        public override void Emit(EnumGenerationSpecification generationSpecification)
        {
            _enumName = generationSpecification.Name;
            _enumExtensionsName = _enumName + "Extensions";
            _enumNamespace = generationSpecification.Namespace!;
            _hasFlagsAttribute = generationSpecification.HasFlagsAttribute;
            _hasTraktParameterEnumAttribute = generationSpecification.HasTraktParameterEnumAttribute;
            _traktParameterEnumAttributeValue = generationSpecification.ParameterEnumAttributeValue;
            _enumMembers = generationSpecification.Members;

            _hasUnspecifiedMember = _enumMembers.Any(m => m.Name == UnspecifiedValue);
            _hasNoneMember = _enumMembers.Any(m => m.Name == NoneValue);
            _invalidValueMember = string.Empty;

            if (_hasUnspecifiedMember)
            {
                _invalidValueMember = UnspecifiedValue;
            }
            else if (_hasNoneMember)
            {
                _invalidValueMember = NoneValue;
            }

            var sourceWriter = new SourceWriter();

            sourceWriter.WriteLine(Constants.Header);

            foreach (string @using in Usings)
            {
                sourceWriter.WriteLine($"using {@using};");
            }

            sourceWriter.WriteEmptyLine();

            sourceWriter.WriteLine($"namespace {_enumNamespace}");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();

            WriteEnumExtensionsClass(sourceWriter);
            sourceWriter.WriteEmptyLine();
            WriteJsonConverterClass(sourceWriter);

            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');

            AddSource(_enumName + EnumConstants.GeneratedTraktEnumFileExtension, sourceWriter.ToSourceText());
        }

        private void WriteEnumExtensionsClass(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Extension methods for <see cref=\"{_enumName}\" />.</summary>");
            sourceWriter.WriteLine($"public static partial class {_enumExtensionsName}");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();

            WriteToJsonMethod(sourceWriter);

            sourceWriter.WriteEmptyLine();
            WriteJsonToEnumMethod(sourceWriter);

            sourceWriter.WriteEmptyLine();
            WriteDisplayNameMethod(sourceWriter);

            if (_hasFlagsAttribute)
            {
                sourceWriter.WriteEmptyLine();
                WriteHasFlagSetMethod(sourceWriter);
            }

            if (_hasTraktParameterEnumAttribute)
            {
                sourceWriter.WriteEmptyLine();
                WriteToUriPathMethod(sourceWriter);
            }

            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteToJsonMethod(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Returns the Json value for <see cref=\"{_enumName}\" />.</summary>");
            sourceWriter.WriteLine($"public static string? ToJson(this {_enumName} value)");
            sourceWriter.Indent();
            sourceWriter.WriteLine("=> value switch");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                string enumMemberName = enumMember.Name;

                if ((enumMemberName == UnspecifiedValue || enumMemberName == NoneValue) && !enumMember.HasTraktEnumMemberAttribute)
                {
                    WriteToJsonSwitchInvalidCase(sourceWriter, enumMemberName);
                }
                else
                {
                    WriteToJsonSwitchCase(sourceWriter, enumMemberName, enumMember.JsonValue);
                }
            }

            sourceWriter.WriteLine("_ => null,");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine("};");
            sourceWriter.DecrementIndent();
        }

        private void WriteToJsonSwitchInvalidCase(SourceWriter sourceWriter, string enumMemberName)
            => sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => null,");

        private void WriteToJsonSwitchCase(SourceWriter sourceWriter, string enumMemberName, string jsonValue)
            => sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => \"{jsonValue}\",");

        private void WriteJsonToEnumMethod(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Returns a <see cref=\"{_enumName}\" /> for the given value, if possible.</summary>");
            sourceWriter.WriteLine($"public static {_enumName} To{_enumName}(this string? value)");
            sourceWriter.Indent();
            sourceWriter.WriteLine("=> value switch");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                WriteFromJsonSwitchCase(sourceWriter, enumMember.Name, enumMember.JsonValue);
            }

            sourceWriter.WriteLine($"_ => {_enumName}.{_invalidValueMember},");

            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine("};");
            sourceWriter.DecrementIndent();
        }

        private void WriteFromJsonSwitchCase(SourceWriter sourceWriter, string enumMemberName, string jsonValue)
            => sourceWriter.WriteLine($"\"{jsonValue}\" => {_enumName}.{enumMemberName},");

        private void WriteDisplayNameMethod(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Returns the display name for <see cref=\"{_enumName}\" />.</summary>");
            sourceWriter.WriteLine($"public static string DisplayName(this {_enumName} value)");

            if (_hasFlagsAttribute)
            {
                WriteDisplayNameMethodForEnumWithFlags(sourceWriter);
            }
            else
            {
                sourceWriter.Indent();
                sourceWriter.WriteLine("=> value switch");
                sourceWriter.WriteLine('{');
                sourceWriter.Indent();

                foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
                {
                    WriteDisplayNameSwitchCase(sourceWriter, enumMember.Name, enumMember.DisplayName);
                }

                sourceWriter.WriteLine("_ => value.ToString(),");
                sourceWriter.DecrementIndent();
                sourceWriter.WriteLine("};");
                sourceWriter.DecrementIndent();
            }
        }

        private void WriteDisplayNameSwitchCase(SourceWriter sourceWriter, string enumMemberName, string displayName)
            => sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => \"{displayName}\",");

        private void WriteDisplayNameMethodForEnumWithFlags(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine("var values = new List<string>();");

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                sourceWriter.WriteEmptyLine();

                string enumMemberName = enumMember.Name;

                if (enumMemberName == UnspecifiedValue || enumMemberName == NoneValue)
                {
                    WriteFlagDisplayNameValuesAdd(sourceWriter, enumMemberName, enumMember.DisplayName);
                }
                else
                {
                    WriteFlagDisplayNameValuesAddWithFlagCheck(sourceWriter, enumMemberName, enumMember.DisplayName);
                }
            }

            sourceWriter.WriteEmptyLine();
            sourceWriter.WriteLine("return string.Join(\", \", values);");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteFlagDisplayNameValuesAdd(SourceWriter sourceWriter, string enumMemberName, string displayName)
        {
            sourceWriter.WriteLine($"if (value == {_enumName}.{enumMemberName})");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine($"values.Add(\"{displayName}\");");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteFlagDisplayNameValuesAddWithFlagCheck(SourceWriter sourceWriter, string enumMemberName, string displayName)
        {
            sourceWriter.WriteLine($"if (value.HasFlagSet({_enumName}.{enumMemberName}))");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine($"values.Add(\"{displayName}\");");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteHasFlagSetMethod(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Determines whether one or more bit fields are set in <see cref=\"{_enumName}\" />.</summary>");
            sourceWriter.WriteLine($"public static bool HasFlagSet(this {_enumName} value, {_enumName} flag)");
            sourceWriter.Indent();
            sourceWriter.WriteLine("=> flag == 0 ? true : (value & flag) == flag;");
            sourceWriter.DecrementIndent();
        }

        private void WriteToUriPathMethod(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>Converts a <see cref=\"{_enumName}\" /> to a valid URI path value.</summary>");
            sourceWriter.WriteLine($"public static string ToUriPath(this {_enumName} value)");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();

            if (_hasUnspecifiedMember || _hasNoneMember)
            {
                sourceWriter.WriteLine($"if (value == {_enumName}.{_invalidValueMember})");
                sourceWriter.WriteLine('{');
                sourceWriter.Indent();
                sourceWriter.WriteLine("return string.Empty;");
                sourceWriter.DecrementIndent();
                sourceWriter.WriteLine('}');
                sourceWriter.WriteEmptyLine();
            }

            if (_hasFlagsAttribute)
            {
                sourceWriter.WriteLine("var values = new List<string>();");

                foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
                {
                    if (enumMember.Name == _invalidValueMember)
                    {
                        continue;
                    }

                    sourceWriter.WriteEmptyLine();
                    WriteToUriPathValueAdd(sourceWriter, enumMember.Name);
                }

                sourceWriter.WriteEmptyLine();
                WriteToUriPathReturn(sourceWriter, @"string.Join("","", values);");
            }
            else
            {
                sourceWriter.WriteEmptyLine();
                WriteToUriPathReturn(sourceWriter, "value.ToJson();");
            }

            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteToUriPathValueAdd(SourceWriter sourceWriter, string enumMemberName)
        {
            sourceWriter.WriteLine($"if (value.HasFlagSet({_enumName}.{enumMemberName}))");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine($"values.Add({_enumName}.{enumMemberName}.ToJson()!);");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }

        private void WriteToUriPathReturn(SourceWriter sourceWriter, string joinValues)
            => sourceWriter.WriteLine($"return \"{_traktParameterEnumAttributeValue}=\" + {joinValues}");

        private void WriteJsonConverterClass(SourceWriter sourceWriter)
        {
            sourceWriter.WriteLine($"/// <summary>JSON converter for <see cref=\"{_enumName}\" />.</summary>");
            sourceWriter.WriteLine($"public sealed class {_enumName}JsonConverter : JsonConverter<{_enumName}>");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine($"public override bool CanConvert(Type typeToConvert) => typeof({_enumName}) == typeToConvert;");
            sourceWriter.WriteEmptyLine();
            sourceWriter.WriteLine($"public override {_enumName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
            sourceWriter.WriteLine('{');
            sourceWriter.Indent();
            sourceWriter.WriteLine("string? enumValue = reader.GetString();");
            sourceWriter.WriteLine($"return string.IsNullOrEmpty(enumValue) ? default : enumValue.To{_enumName}();");
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
            sourceWriter.WriteEmptyLine();
            sourceWriter.WriteLine($"public override void Write(Utf8JsonWriter writer, {_enumName} value, JsonSerializerOptions options)");
            sourceWriter.Indent();
            sourceWriter.WriteLine("=> writer.WriteStringValue(value.ToJson());");
            sourceWriter.DecrementIndent();
            sourceWriter.DecrementIndent();
            sourceWriter.WriteLine('}');
        }
    }
}
