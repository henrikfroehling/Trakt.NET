using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    internal abstract class TraktRequestParser<T> where T : RequestGenerationSpecification
    {
        protected readonly KnownRequestSymbols _knownRequestSymbols;

        internal List<DiagnosticInfo> Diagnostics { get; } = [];

        internal TraktRequestParser(KnownRequestSymbols knownRequestSymbols) => _knownRequestSymbols = knownRequestSymbols;

        internal abstract T? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken);
    }
}
