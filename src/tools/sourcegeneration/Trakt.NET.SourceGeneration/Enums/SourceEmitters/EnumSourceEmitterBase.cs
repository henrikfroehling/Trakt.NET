using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Enums
{
    public abstract class EnumSourceEmitterBase<T>(SourceProductionContext context) : SourceEmitter<T>(context) where T : EnumGenerationSpecification
    {
        private const string UnspecifiedValue = "Unspecified";
        private const string NoneValue = "None";

        private static readonly IReadOnlyList<string> Usings = [
            "System.Text.Json",
            "System.Text.Json.Serialization"
        ];

        protected SourceWriter _sourceWriter = new();

        protected bool _hasUnspecifiedMember;
        protected bool _hasNoneMember;
        protected string _invalidValueMember = string.Empty;

        protected string _enumName = string.Empty;
        protected string _enumExtensionsName = string.Empty;
        protected string _enumNamespace = string.Empty;
        protected bool _hasFlagsAttribute;
        protected List<EnumMemberGenerationSpecification> _enumMembers = [];

        public override void Emit(T generationSpecification)
        {
            if (generationSpecification == null)
            {
                return;
            }

            Setup(generationSpecification);

            WriteHeaderAndUsings();
            WriteNamespaceStart();

            WriteEnumExtensionsClass();
            _sourceWriter.WriteEmptyLine();
            WriteJsonConverterClass();

            WriteNamespaceEnd();

            AddSource(_enumName + EnumConstants.GeneratedTraktEnumFileExtension, _sourceWriter.ToSourceText());
        }

        protected virtual void Setup(T enumGenerationSpecification)
        {
            _enumName = enumGenerationSpecification.Name;
            _enumExtensionsName = _enumName + "Extensions";
            _enumNamespace = enumGenerationSpecification.Namespace!;
            _hasFlagsAttribute = enumGenerationSpecification.HasFlagsAttribute;
            _enumMembers = enumGenerationSpecification.Members;

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
        }

        protected virtual void WriteExtensionsClassContent()
        {
            WriteToJsonMethod();

            _sourceWriter.WriteEmptyLine();
            WriteJsonToEnumMethod();

            _sourceWriter.WriteEmptyLine();
            WriteDisplayNameMethod();

            if (_hasFlagsAttribute)
            {
                _sourceWriter.WriteEmptyLine();
                WriteHasFlagSetMethod();
            }
        }

        private void WriteHeaderAndUsings()
        {
            _sourceWriter.WriteLine(Constants.Header);

            foreach (string @using in Usings)
            {
                _sourceWriter.WriteLine($"using {@using};");
            }

            _sourceWriter.WriteEmptyLine();
        }

        private void WriteNamespaceStart()
        {
            _sourceWriter.WriteLine($"namespace {_enumNamespace}");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
        }

        private void WriteNamespaceEnd()
        {
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteEnumExtensionsClass()
        {
            _sourceWriter.WriteLine($"/// <summary>Extension methods for <see cref=\"{_enumName}\" />.</summary>");
            _sourceWriter.WriteLine($"public static partial class {_enumExtensionsName}");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            WriteExtensionsClassContent();

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteToJsonMethod()
        {
            _sourceWriter.WriteLine($"/// <summary>Returns the Json value for <see cref=\"{_enumName}\" />.</summary>");
            _sourceWriter.WriteLine($"public static string? ToJson(this {_enumName} value)");
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("=> value switch");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                string enumMemberName = enumMember.Name;

                if ((enumMemberName == UnspecifiedValue || enumMemberName == NoneValue) && !enumMember.HasTraktEnumMemberAttribute)
                {
                    WriteToJsonSwitchInvalidCase(enumMemberName);
                }
                else
                {
                    WriteToJsonSwitchCase(enumMemberName, enumMember.JsonValue);
                }
            }

            _sourceWriter.WriteLine("_ => null,");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine("};");
            _sourceWriter.DecrementIndent();
        }

        private void WriteToJsonSwitchInvalidCase(string enumMemberName)
            => _sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => null,");

        private void WriteToJsonSwitchCase(string enumMemberName, string jsonValue)
            => _sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => \"{jsonValue}\",");

        private void WriteJsonToEnumMethod()
        {
            _sourceWriter.WriteLine($"/// <summary>Returns a <see cref=\"{_enumName}\" /> for the given value, if possible.</summary>");
            _sourceWriter.WriteLine($"public static {_enumName} To{_enumName}(this string? value)");
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("=> value switch");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                WriteFromJsonSwitchCase(enumMember.Name, enumMember.JsonValue);
            }

            _sourceWriter.WriteLine($"_ => {_enumName}.{_invalidValueMember},");

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine("};");
            _sourceWriter.DecrementIndent();
        }

        private void WriteFromJsonSwitchCase(string enumMemberName, string jsonValue)
            => _sourceWriter.WriteLine($"\"{jsonValue}\" => {_enumName}.{enumMemberName},");

        private void WriteDisplayNameMethod()
        {
            _sourceWriter.WriteLine($"/// <summary>Returns the display name for <see cref=\"{_enumName}\" />.</summary>");
            _sourceWriter.WriteLine($"public static string DisplayName(this {_enumName} value)");

            if (_hasFlagsAttribute)
            {
                WriteDisplayNameMethodForEnumWithFlags();
            }
            else
            {
                _sourceWriter.Indent();
                _sourceWriter.WriteLine("=> value switch");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();

                foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
                {
                    WriteDisplayNameSwitchCase(enumMember.Name, enumMember.DisplayName);
                }

                _sourceWriter.WriteLine("_ => value.ToString(),");
                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine("};");
                _sourceWriter.DecrementIndent();
            }
        }

        private void WriteDisplayNameSwitchCase(string enumMemberName, string displayName)
            => _sourceWriter.WriteLine($"{_enumName}.{enumMemberName} => \"{displayName}\",");

        private void WriteDisplayNameMethodForEnumWithFlags()
        {
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("var values = new List<string>();");

            foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
            {
                _sourceWriter.WriteEmptyLine();

                string enumMemberName = enumMember.Name;

                if (enumMemberName == UnspecifiedValue || enumMemberName == NoneValue)
                {
                    WriteFlagDisplayNameValuesAdd(enumMemberName, enumMember.DisplayName);
                }
                else
                {
                    WriteFlagDisplayNameValuesAddWithFlagCheck(enumMemberName, enumMember.DisplayName);
                }
            }

            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine("return string.Join(\", \", values);");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteFlagDisplayNameValuesAdd(string enumMemberName, string displayName)
        {
            _sourceWriter.WriteLine($"if (value == {_enumName}.{enumMemberName})");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"values.Add(\"{displayName}\");");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteFlagDisplayNameValuesAddWithFlagCheck(string enumMemberName, string displayName)
        {
            _sourceWriter.WriteLine($"if (value.HasFlagSet({_enumName}.{enumMemberName}))");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"values.Add(\"{displayName}\");");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteHasFlagSetMethod()
        {
            _sourceWriter.WriteLine($"/// <summary>Determines whether one or more bit fields are set in <see cref=\"{_enumName}\" />.</summary>");
            _sourceWriter.WriteLine($"public static bool HasFlagSet(this {_enumName} value, {_enumName} flag)");
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("=> flag == 0 ? true : (value & flag) == flag;");
            _sourceWriter.DecrementIndent();
        }

        private void WriteJsonConverterClass()
        {
            _sourceWriter.WriteLine($"/// <summary>JSON converter for <see cref=\"{_enumName}\" />.</summary>");
            _sourceWriter.WriteLine($"public sealed class {_enumName}JsonConverter : JsonConverter<{_enumName}>");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"public override bool CanConvert(Type typeToConvert) => typeof({_enumName}) == typeToConvert;");
            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine($"public override {_enumName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("string? enumValue = reader.GetString();");
            _sourceWriter.WriteLine($"return string.IsNullOrEmpty(enumValue) ? default : enumValue.To{_enumName}();");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine($"public override void Write(Utf8JsonWriter writer, {_enumName} value, JsonSerializerOptions options)");
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("=> writer.WriteStringValue(value.ToJson());");
            _sourceWriter.DecrementIndent();
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }
    }
}
