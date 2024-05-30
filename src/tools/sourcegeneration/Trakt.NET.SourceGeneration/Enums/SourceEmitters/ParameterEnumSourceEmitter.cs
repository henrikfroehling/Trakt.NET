using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Enums
{
    public sealed class ParameterEnumSourceEmitter(SourceProductionContext context)
        : EnumSourceEmitterBase<ParameterEnumGenerationSpecification>(context)
    {
        private string _traktParameterEnumAttributeValue = string.Empty;

        protected override void Setup(ParameterEnumGenerationSpecification enumGenerationSpecification)
        {
            base.Setup(enumGenerationSpecification);
            _traktParameterEnumAttributeValue = enumGenerationSpecification.ParameterEnumAttributeValue;
        }

        protected override void WriteExtensionsClassContent()
        {
            base.WriteExtensionsClassContent();

            _sourceWriter.WriteEmptyLine();
            WriteToUriPathMethod();
        }

        private void WriteToUriPathMethod()
        {
            _sourceWriter.WriteLine($"/// <summary>Converts a <see cref=\"{_enumName}\" /> to a valid URI path value.</summary>");
            _sourceWriter.WriteLine($"public static string ToUriPath(this {_enumName} value)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            if (_hasUnspecifiedMember || _hasNoneMember)
            {
                _sourceWriter.WriteLine($"if (value == {_enumName}.{_invalidValueMember})");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();
                _sourceWriter.WriteLine("return string.Empty;");
                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
                _sourceWriter.WriteEmptyLine();
            }

            if (_hasFlagsAttribute)
            {
                _sourceWriter.WriteLine("var values = new List<string>();");

                foreach (EnumMemberGenerationSpecification enumMember in _enumMembers)
                {
                    if (enumMember.Name == _invalidValueMember)
                    {
                        continue;
                    }

                    _sourceWriter.WriteEmptyLine();
                    WriteToUriPathValueAdd(enumMember.Name);
                }

                _sourceWriter.WriteEmptyLine();
                WriteToUriPathReturn(@"string.Join("","", values);");
            }
            else
            {
                _sourceWriter.WriteEmptyLine();
                WriteToUriPathReturn("value.ToJson();");
            }

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteToUriPathValueAdd(string enumMemberName)
        {
            _sourceWriter.WriteLine($"if (value.HasFlagSet({_enumName}.{enumMemberName}))");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"values.Add({_enumName}.{enumMemberName}.ToJson()!);");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteToUriPathReturn(string joinValues)
            => _sourceWriter.WriteLine($"return \"{_traktParameterEnumAttributeValue}=\" + {joinValues}");
    }
}
