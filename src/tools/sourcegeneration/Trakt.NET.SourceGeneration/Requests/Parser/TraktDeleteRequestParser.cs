using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktDeleteRequestParser : TraktRequestParser<DeleteRequestGenerationSpecification>
    {
        private readonly bool _compilationContainsDeleteRequestType;

        internal TraktDeleteRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsDeleteRequestType = _knownRequestSymbols.TraktDeleteRequestAttributeType != null;

        internal override DeleteRequestGenerationSpecification? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsDeleteRequestType)
            {
                return null;
            }

            return null;
        }
    }
}
