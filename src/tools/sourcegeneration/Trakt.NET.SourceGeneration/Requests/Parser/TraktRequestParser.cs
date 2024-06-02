using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Diagnostics;
using TraktNET.SourceGeneration.Common;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    internal abstract class TraktRequestParser<T> where T : RequestGenerationSpecification
    {
        protected readonly KnownRequestSymbols _knownRequestSymbols;
        protected bool _compilationContainsRequestType;
        protected INamedTypeSymbol? _requestClassDeclarationSymbol;
        protected Location? _requestClassDeclarationLocation;

        protected string _httpMethodValue = string.Empty;
        protected string _uriPath = string.Empty;
        protected bool _requestSupportsExtendedInfo;
        protected bool _requestSupportsPagination;
        protected bool _requestHasOAuthRequirementDefined;
        protected string _requestOAuthRequirementValue = string.Empty;

        internal List<DiagnosticInfo> Diagnostics { get; } = [];

        internal TraktRequestParser(KnownRequestSymbols knownRequestSymbols) => _knownRequestSymbols = knownRequestSymbols;

        internal T? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsRequestType)
            {
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();
            GetClassSymbolAndLocation(classDeclaration, semanticModel, cancellationToken);

            return !ParseAttribute(cancellationToken) ? null : CreateSpecification();
        }

        private bool ParseAttribute(CancellationToken cancellationToken)
        {
            foreach (AttributeData attributeData in _requestClassDeclarationSymbol!.GetAttributes())
            {
                cancellationToken.ThrowIfCancellationRequested();

                INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                Location? attributeLocation = null;

                if (attributeClass!.Locations.Length > 0)
                {
                    attributeLocation = attributeClass!.Locations[0];
                }

                bool isTraktRequestAttribute =
                    SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktGetRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktPostRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktPutRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktDeleteRequestAttributeType);

                if (isTraktRequestAttribute)
                {
                    return ParseRequestAttribute(attributeData, attributeLocation, cancellationToken);
                }
            }

            return true;
        }

        protected abstract T? CreateSpecification();

        protected void ReportDiagnostic(DiagnosticDescriptor descriptor, Location? location)
        {
            Debug.Assert(_requestClassDeclarationLocation != null);

            if (location == null || (location.SourceTree != null && !_knownRequestSymbols.Compilation.ContainsSyntaxTree(location.SourceTree)))
            {
                location = _requestClassDeclarationLocation;
            }

            Diagnostics.Add(DiagnosticInfo.Create(descriptor, location));
        }

        private void GetClassSymbolAndLocation(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            _requestClassDeclarationSymbol = semanticModel.GetDeclaredSymbol(classDeclaration, cancellationToken);
            Debug.Assert(_requestClassDeclarationSymbol != null);

            if (_requestClassDeclarationSymbol != null && _requestClassDeclarationSymbol.Locations.Length > 0)
            {
                _requestClassDeclarationLocation = _requestClassDeclarationSymbol.Locations[0];
            }

            Debug.Assert(_requestClassDeclarationLocation != null);
        }

        private bool ParseRequestAttribute(AttributeData attributeData, Location? attributeLocation, CancellationToken cancellationToken)
        {
            GetHttpMethodValue(attributeData, cancellationToken);

            ImmutableArray<TypedConstant> constructorArguments = attributeData.ConstructorArguments;
            string? uriPathValue = constructorArguments[0].Value as string;

            if (string.IsNullOrEmpty(uriPathValue))
            {
                ReportDiagnostic(DiagnosticDescriptors.InvalidRequestUriPathValue, attributeLocation);
                return false;
            }
            else
            {
                _uriPath = uriPathValue!;
            }

            var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

            if (_knownRequestSymbols.TraktExtendedInfoEnumType != null)
            {
                if (namedArguments.TryGetValue(RequestConstants.TraktRequestPropertySupportsExtendedInfoName, out TypedConstant supportsExtendedInfoConstant))
                {
                    if (supportsExtendedInfoConstant.Value is bool supportsExtendedInfo)
                    {
                        _requestSupportsExtendedInfo = supportsExtendedInfo;
                    }
                }
            }

            if (namedArguments.TryGetValue(RequestConstants.TraktRequestPropertySupportsPaginationName, out TypedConstant supportsPaginationConstant))
            {
                if (supportsPaginationConstant.Value is bool supportsPagination)
                {
                    _requestSupportsPagination = supportsPagination;
                }
            }

            if (_knownRequestSymbols.TraktOAuthRequirementEnumType != null)
            {
                if (namedArguments.TryGetValue(RequestConstants.TraktRequestPropertyOAuthRequirementName, out TypedConstant oauthRequirementConstant))
                {
                    if (SymbolEqualityComparer.Default.Equals(oauthRequirementConstant.Type, _knownRequestSymbols.TraktOAuthRequirementEnumType))
                    {
                        if (oauthRequirementConstant.Value is int requirementValue)
                        {
                            _requestHasOAuthRequirementDefined = _knownRequestSymbols.TraktOAuthRequirementValues.Count > 0;
                            
                            IFieldSymbol? enumField = _knownRequestSymbols.TraktOAuthRequirementValues
                                .FirstOrDefault(x => x.ConstantValue is int enumValue && enumValue == requirementValue);

                            if (enumField != null)
                            {
                                _requestOAuthRequirementValue = enumField.Name;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void GetHttpMethodValue(AttributeData attributeData, CancellationToken cancellationToken)
        {
            SyntaxReference declaredSyntaxReference = attributeData.AttributeClass!.DeclaringSyntaxReferences[0];
            SyntaxNode rootNode = declaredSyntaxReference.SyntaxTree.GetRoot(cancellationToken);

            var attributeVisitor = new AttributeHttpMethodCollector();
            attributeVisitor.Visit(rootNode);
            _httpMethodValue = attributeVisitor.HttpMethod;
        }

        private sealed class AttributeHttpMethodCollector : CSharpSyntaxWalker
        {
            public string HttpMethod { get; private set; } = string.Empty;

            public override void VisitPrimaryConstructorBaseType(PrimaryConstructorBaseTypeSyntax node)
            {
                if (node.Type.ToString() == RequestConstants.TraktRequestAttributeName)
                {
                    if (node.ArgumentList.Arguments[0].Expression is MemberAccessExpressionSyntax httpMethodArgument)
                    {
                        HttpMethod = httpMethodArgument.Name.ToString();
                    }
                }
            }
        }
    }
}
