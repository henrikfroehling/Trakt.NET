using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktGetRequestParser : TraktRequestParser<GetRequestGenerationSpecification>
    {
        private readonly bool _compilationContainsGetRequestType;

        internal TraktGetRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsGetRequestType = _knownRequestSymbols.TraktGetRequestAttributeType != null;

        internal override GetRequestGenerationSpecification? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsGetRequestType)
            {
                return null;
            }

            return null;
        }
    }
}
