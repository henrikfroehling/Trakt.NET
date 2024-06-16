using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Diagnostics;
using TraktNET.SourceGeneration.Common;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    internal sealed class TraktEnumDeclarationParser
    {
        private readonly KnownEnumSymbols _knownEnumSymbols;
        private readonly bool _compilationContainsTraktEnumTypes;
        private INamedTypeSymbol? _enumDeclarationSymbol;
        private Location? _enumDeclarationLocation;
        private bool _hasFlagsAttribute;
        private string _parameterEnumAttributeValue = string.Empty;
        private readonly List<EnumMemberGenerationSpecification> _enumMembers = [];

        public List<DiagnosticInfo> Diagnostics { get; } = [];

        public TraktEnumDeclarationParser(KnownEnumSymbols knownEnumSymbols)
        {
            _knownEnumSymbols = knownEnumSymbols;

            _compilationContainsTraktEnumTypes =
                _knownEnumSymbols.TraktEnumAttributeType != null || _knownEnumSymbols.TraktParameterEnumAttributeType != null;
        }

        public EnumGenerationSpecification? ParseTraktEnumDeclaration(EnumDeclarationSyntax enumDeclaration,
            SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsTraktEnumTypes)
            {
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();

            GetEnumSymbolAndLocation(enumDeclaration, semanticModel, cancellationToken);

            if (!ParseEnumAttributes(_enumDeclarationSymbol!, false, cancellationToken))
            {
                return null;
            }

            if (!ParseEnumMembers(_enumDeclarationSymbol!, cancellationToken))
            {
                return null;
            }

            return new EnumGenerationSpecification
            {
                Name = _enumDeclarationSymbol!.Name,
                Namespace = _enumDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HasFlagsAttribute = _hasFlagsAttribute,
                Members = _enumMembers
            };
        }

        public ParameterEnumGenerationSpecification? ParseTraktParameterEnumDeclaration(EnumDeclarationSyntax enumDeclaration,
            SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsTraktEnumTypes)
            {
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();

            GetEnumSymbolAndLocation(enumDeclaration, semanticModel, cancellationToken);

            if (!ParseEnumAttributes(_enumDeclarationSymbol!, true, cancellationToken))
            {
                return null;
            }

            if (!ParseEnumMembers(_enumDeclarationSymbol!, cancellationToken))
            {
                return null;
            }

            return new ParameterEnumGenerationSpecification
            {
                Name = _enumDeclarationSymbol!.Name,
                Namespace = _enumDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HasFlagsAttribute = _hasFlagsAttribute,
                ParameterEnumAttributeValue = _parameterEnumAttributeValue,
                Members = _enumMembers
            };
        }

        private void GetEnumSymbolAndLocation(EnumDeclarationSyntax enumDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            _enumDeclarationSymbol = (INamedTypeSymbol?)semanticModel.GetDeclaredSymbol(enumDeclaration, cancellationToken);
            Debug.Assert(_enumDeclarationSymbol != null);

            if (_enumDeclarationSymbol != null && _enumDeclarationSymbol.Locations.Length > 0)
            {
                _enumDeclarationLocation = _enumDeclarationSymbol.Locations[0];
            }

            Debug.Assert(_enumDeclarationLocation != null);
        }

        private bool ParseEnumAttributes(INamedTypeSymbol enumTypeSymbol, bool parseTraktParameterEnum, CancellationToken cancellationToken)
        {
            foreach (AttributeData attributeData in enumTypeSymbol.GetAttributes())
            {
                cancellationToken.ThrowIfCancellationRequested();

                INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.SystemFlagsAttributeType))
                {
                    _hasFlagsAttribute = true;
                }                
                else if (parseTraktParameterEnum && SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktParameterEnumAttributeType))
                {
                    ImmutableArray<TypedConstant> constructorArguments = attributeData.ConstructorArguments;
                    string? parameterEnumValue = constructorArguments[0].Value as string;

                    if (string.IsNullOrWhiteSpace(parameterEnumValue))
                    {
                        ReportDiagnostic(DiagnosticDescriptors.InvalidTraktParameterEnumValue);
                        return false;
                    }
                    else
                    {
                        _parameterEnumAttributeValue = parameterEnumValue!;
                    }
                }
            }

            return true;
        }

        private bool ParseEnumMembers(INamedTypeSymbol enumTypeSymbol, CancellationToken cancellationToken)
        {
            foreach (ISymbol enumMember in enumTypeSymbol.GetMembers())
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (enumMember is not IFieldSymbol enumField || enumField.ConstantValue == null)
                {
                    continue;
                }

                string enumMemberName = enumField.Name;
                string displayName = enumMemberName.ToDisplayName();
                string jsonValue = enumMemberName.ToLowercaseNamingConvention();
                bool hasTraktEnumMemberAttribute = false;

                foreach (AttributeData attributeData in enumField.GetAttributes())
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                    if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktEnumMemberAttributeType))
                    {
                        hasTraktEnumMemberAttribute = true;
                        ImmutableArray<TypedConstant> constructorArguments = attributeData.ConstructorArguments;

                        if (constructorArguments[0].Value is not string value)
                        {
                            ReportDiagnostic(DiagnosticDescriptors.InvalidJsonValue);
                            return false;
                        }
                        else
                        {
                            jsonValue = value!;
                        }

                        var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                        if (namedArguments.TryGetValue(EnumConstants.TraktEnumMemberPropertyDisplayName, out TypedConstant displayNameConstant))
                        {
                            if (displayNameConstant.Value is not string displayNameValue)
                            {
                                ReportDiagnostic(DiagnosticDescriptors.InvalidDisplayNameValue);
                                return false;
                            }
                            else
                            {
                                displayName = displayNameValue!;
                            }
                        }
                    }
                }

                _enumMembers.Add(new EnumMemberGenerationSpecification
                {
                    Name = enumMemberName,
                    HasTraktEnumMemberAttribute = hasTraktEnumMemberAttribute,
                    DisplayName = displayName,
                    JsonValue = jsonValue
                });
            }

            return true;
        }

        private void ReportDiagnostic(DiagnosticDescriptor descriptor)
        {
            Debug.Assert(_enumDeclarationLocation != null);
            Diagnostics.Add(DiagnosticInfo.Create(descriptor, _enumDeclarationLocation));
        }
    }
}
