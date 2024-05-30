global using EnumDeclarationSyntaxTuple =
    ((Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax ContextClass, Microsoft.CodeAnalysis.SemanticModel SemanticModel) EnumDeclarationContext,
    TraktNET.SourceGeneration.Enums.KnownEnumSymbols KnownEnumSymbols);

global using EnumGenerationSpecificationTuple =
    (TraktNET.SourceGeneration.Enums.EnumGenerationSpecification? EnumGenerationSpecification,
        TraktNET.SourceGeneration.Models.ImmutableEquatableArray<TraktNET.SourceGeneration.Models.DiagnosticInfo> Diagnostics);

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    public abstract class TraktEnumSourceGeneratorBase<T> where T : EnumGenerationSpecification
    {
        protected IncrementalValueProvider<KnownEnumSymbols> _knownEnumTypeSymbols;
        protected IncrementalValuesProvider<EnumGenerationSpecificationTuple> _enumGenerationSpecifications;

        protected void InitializeGenerator(IncrementalGeneratorInitializationContext context)
        {
            _knownEnumTypeSymbols = context.CompilationProvider.Select(static (compilation, _) => new KnownEnumSymbols(compilation));
            _enumGenerationSpecifications = CombineAndSelectEnumsWithAttribute(context);
            context.RegisterSourceOutput(_enumGenerationSpecifications, ReportDiagnosticsAndEmitSource);
        }

        protected abstract IncrementalValuesProvider<EnumGenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context);

        protected abstract EnumGenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken);

        protected abstract EnumSourceEmitterBase<T> CreateSourceEmitter(SourceProductionContext context);

        protected IncrementalValuesProvider<EnumGenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
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

        protected void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, EnumGenerationSpecificationTuple input)
        {
            foreach (DiagnosticInfo diagnosticInfo in input.Diagnostics)
            {
                sourceProductionContext.ReportDiagnostic(diagnosticInfo.CreateDiagnostic());
            }

            if (input.EnumGenerationSpecification == null)
            {
                return;
            }

            EnumSourceEmitterBase<T> enumSourceEmitter = CreateSourceEmitter(sourceProductionContext);
            enumSourceEmitter.Emit((T)input.EnumGenerationSpecification);
        }
    }
}
