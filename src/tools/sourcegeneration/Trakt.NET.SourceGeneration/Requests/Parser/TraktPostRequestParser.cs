using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktPostRequestParser : TraktRequestParser<PostRequestGenerationSpecification>
    {
        private readonly bool _compilationContainsPostRequestType;

        internal TraktPostRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsPostRequestType = _knownRequestSymbols.TraktPostRequestAttributeType != null;

        internal override PostRequestGenerationSpecification? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsPostRequestType)
            {
                return null;
            }

            return null;
        }
    }
}
