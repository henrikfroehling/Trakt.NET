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
        private bool _hasParameterEnumAttribute;
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

            ParseEnumMembers(_enumDeclarationSymbol!, cancellationToken);

            return new EnumGenerationSpecification
            {
                Name = _enumDeclarationSymbol!.Name,
                Namespace = _enumDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HasFlagsAttribute = _hasFlagsAttribute,
                HasTraktParameterEnumAttribute = _hasParameterEnumAttribute,
                ParameterEnumAttributeValue = _parameterEnumAttributeValue,
                Members = _enumMembers
            };
        }

        public EnumGenerationSpecification? ParseTraktParameterEnumDeclaration(EnumDeclarationSyntax enumDeclaration,
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

            ParseEnumMembers(_enumDeclarationSymbol!, cancellationToken);

            return new EnumGenerationSpecification
            {
                Name = _enumDeclarationSymbol!.Name,
                Namespace = _enumDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HasFlagsAttribute = _hasFlagsAttribute,
                HasTraktParameterEnumAttribute = _hasParameterEnumAttribute,
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

                Location? attributeLocation = null;

                if (attributeClass!.Locations.Length > 0)
                    attributeLocation = attributeClass!.Locations[0];

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
                        ReportDiagnostic(DiagnosticDescriptors.InvalidTraktParameterEnumValue, attributeLocation);
                        return false;
                    }
                    else
                    {
                        _hasParameterEnumAttribute = true;
                        _parameterEnumAttributeValue = parameterEnumValue!;
                    }
                }
            }

            return true;
        }

        private void ParseEnumMembers(INamedTypeSymbol enumTypeSymbol, CancellationToken cancellationToken)
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
                bool addMember = true;

                foreach (AttributeData attributeData in enumField.GetAttributes())
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                    if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktEnumMemberAttributeType))
                    {
                        hasTraktEnumMemberAttribute = true;
                        Location? attributeLocation = null;

                        if (attributeClass!.Locations.Length > 0)
                            attributeLocation = attributeClass!.Locations[0];

                        ImmutableArray<TypedConstant> constructorArguments = attributeData.ConstructorArguments;
                        string? value = constructorArguments[0].Value as string;

                        if (value == null)
                        {
                            ReportDiagnostic(DiagnosticDescriptors.InvalidJsonValue, attributeLocation);
                            addMember = false;
                        }
                        else
                        {
                            jsonValue = value!;
                        }

                        var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                        if (namedArguments.TryGetValue(EnumConstants.TraktEnumMemberJsonValuePropertyDisplayName, out TypedConstant displayNameConstant))
                        {
                            string? displayNameValue = displayNameConstant.Value as string;

                            if (displayNameValue == null)
                            {
                                ReportDiagnostic(DiagnosticDescriptors.InvalidDisplayNameValue, attributeLocation);
                                addMember = false;
                            }
                            else
                            {
                                displayName = displayNameValue!;
                            }
                        }
                    }
                }

                if (addMember)
                {
                    _enumMembers.Add(new EnumMemberGenerationSpecification
                    {
                        Name = enumMemberName,
                        HasTraktEnumMemberAttribute = hasTraktEnumMemberAttribute,
                        DisplayName = displayName,
                        JsonValue = jsonValue
                    });
                }
            }
        }

        private void ReportDiagnostic(DiagnosticDescriptor descriptor, Location? location)
        {
            Debug.Assert(_enumDeclarationLocation != null);

            if (location == null || (location.SourceTree != null && !_knownEnumSymbols.Compilation.ContainsSyntaxTree(location.SourceTree)))
            {
                location = _enumDeclarationLocation;
            }

            Diagnostics.Add(DiagnosticInfo.Create(descriptor, location));
        }
    }
}
