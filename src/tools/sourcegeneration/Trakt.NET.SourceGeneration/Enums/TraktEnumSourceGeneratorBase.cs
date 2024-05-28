using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraktNET.SourceGeneration.Models;

using EnumDeclarationSyntaxTuple =
    ((Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax ContextClass, Microsoft.CodeAnalysis.SemanticModel SemanticModel) EnumDeclarationContext,
    TraktNET.SourceGeneration.Enums.KnownEnumSymbols KnownEnumSymbols);

using GenerationSpecificationTuple =
    (TraktNET.SourceGeneration.Enums.EnumGenerationSpecification? EnumGenerationSpecification,
        TraktNET.SourceGeneration.Models.ImmutableEquatableArray<TraktNET.SourceGeneration.Models.DiagnosticInfo> Diagnostics);

namespace TraktNET.SourceGeneration.Enums
{
    public abstract class TraktEnumSourceGeneratorBase
    {
        protected IncrementalValueProvider<KnownEnumSymbols> _knownEnumTypeSymbols;
        protected IncrementalValuesProvider<GenerationSpecificationTuple> _enumGenerationSpecifications;

        protected void InitializeGenerator(IncrementalGeneratorInitializationContext context)
        {
            _knownEnumTypeSymbols = context.CompilationProvider.Select(static (compilation, _) => new KnownEnumSymbols(compilation));
            _enumGenerationSpecifications = CombineAndSelectEnumsWithAttribute(context);
            context.RegisterSourceOutput(_enumGenerationSpecifications, ReportDiagnosticsAndEmitSource);
        }

        protected abstract IncrementalValuesProvider<GenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context);

        protected abstract GenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken);

        protected IncrementalValuesProvider<GenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context, string enumAttributeName, string initialTrackingName,
            string filteredTrackingName)
            => context.SyntaxProvider
                .ForAttributeWithMetadataName(enumAttributeName,
                    static (syntaxNode, _) => syntaxNode is EnumDeclarationSyntax,
                    (context, _) => (ContextClass: (EnumDeclarationSyntax)context.TargetNode, context.SemanticModel))
                .WithTrackingName(initialTrackingName)
                .Combine(_knownEnumTypeSymbols)
                .Select(ParseEnumDeclaration)
                .WithTrackingName(filteredTrackingName);

        protected static void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, GenerationSpecificationTuple input)
        {
            foreach (DiagnosticInfo diagnosticInfo in input.Diagnostics)
            {
                sourceProductionContext.ReportDiagnostic(diagnosticInfo.CreateDiagnostic());
            }

            if (input.EnumGenerationSpecification == null)
            {
                return;
            }

            EnumSourceEmitter enumSourceEmitter = new(sourceProductionContext);
            enumSourceEmitter.Emit(input.EnumGenerationSpecification);
        }
    }
}
