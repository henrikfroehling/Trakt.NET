global using RequestClassDeclarationSyntaxTuple =
    ((Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax ContextClass, Microsoft.CodeAnalysis.SemanticModel SemanticModel) ClassDeclarationContext,
    TraktNET.SourceGeneration.Requests.KnownRequestSymbols KnownRequestSymbols);

global using RequestGenerationSpecificationTuple =
    (TraktNET.SourceGeneration.Requests.RequestGenerationSpecification? RequestGenerationSpecification,
        TraktNET.SourceGeneration.Models.ImmutableEquatableArray<TraktNET.SourceGeneration.Models.DiagnosticInfo> Diagnostics);

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    public abstract class TraktRequestSourceGeneratorBase<T> where T : RequestGenerationSpecification
    {
        protected IncrementalValueProvider<KnownRequestSymbols> _knownRequestTypeSymbols;
        protected IncrementalValuesProvider<RequestGenerationSpecificationTuple> _requestGenerationSpecifications;

        protected void InitializeGenerator(IncrementalGeneratorInitializationContext context)
        {
            _knownRequestTypeSymbols = context.CompilationProvider.Select(static (compilation, _) => new KnownRequestSymbols(compilation));
            _requestGenerationSpecifications = CombineAndSelectRequestsWithAttribute(context);
            context.RegisterSourceOutput(_requestGenerationSpecifications, ReportDiagnosticsAndEmitSource);
        }

        protected abstract IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context);

        protected abstract RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken);

        protected abstract RequestSourceEmitterBase<T> CreateSourceEmitter(SourceProductionContext context);

        protected IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context, string requestAttributeName, string initialTrackingName,
            string filteredTrackingName)
            => context.SyntaxProvider
                .ForAttributeWithMetadataName(requestAttributeName,
                    static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
                    (context, _) => (ContextClass: (ClassDeclarationSyntax)context.TargetNode, context.SemanticModel))
                .WithTrackingName(initialTrackingName)
                .Combine(_knownRequestTypeSymbols)
                .Select(ParseClassDeclaration)
                .WithTrackingName(filteredTrackingName);

        protected void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, RequestGenerationSpecificationTuple input)
        {
            foreach (DiagnosticInfo diagnosticInfo in input.Diagnostics)
            {
                sourceProductionContext.ReportDiagnostic(diagnosticInfo.CreateDiagnostic());
            }

            if (input.RequestGenerationSpecification == null)
            {
                return;
            }

            RequestSourceEmitterBase<T> requestSourceEmitter = CreateSourceEmitter(sourceProductionContext);
            requestSourceEmitter.Emit((T)input.RequestGenerationSpecification);
        }
    }
}
