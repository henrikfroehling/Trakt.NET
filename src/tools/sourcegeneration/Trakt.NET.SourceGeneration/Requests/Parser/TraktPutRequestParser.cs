using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktPutRequestParser : TraktRequestParser<PutRequestGenerationSpecification>
    {
        private readonly bool _compilationContainsPutRequestType;

        internal TraktPutRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsPutRequestType = _knownRequestSymbols.TraktPutRequestAttributeType != null;

        internal override PutRequestGenerationSpecification? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsPutRequestType)
            {
                return null;
            }

            return null;
        }
    }
}
