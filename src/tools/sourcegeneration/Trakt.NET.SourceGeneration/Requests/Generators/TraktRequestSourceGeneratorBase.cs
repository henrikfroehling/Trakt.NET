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
    public abstract class TraktRequestSourceGeneratorBase
    {
        protected IncrementalValueProvider<KnownRequestSymbols> _knownRequestTypeSymbols;
        protected IncrementalValuesProvider<RequestGenerationSpecificationTuple> _requestGenerationSpecifications;

        protected void InitializeGenerator(IncrementalGeneratorInitializationContext context)
        {
            _knownRequestTypeSymbols = context.CompilationProvider.Select(static (compilation, _) => new KnownRequestSymbols(compilation));
            _requestGenerationSpecifications = CombineAndSelectRequestsWithAttribute(context);
            context.RegisterSourceOutput(_requestGenerationSpecifications, ReportDiagnosticsAndEmitSource);
        }

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

        protected abstract IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context);

        private RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken)
        {
            var parser = new TraktRequestParser(classDeclarationInput.KnownRequestSymbols);

            RequestGenerationSpecification? requestGenerationSpecification =
                parser.Parse(classDeclarationInput.ClassDeclarationContext.ContextClass,
                    classDeclarationInput.ClassDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (requestGenerationSpecification, diagnostics);
        }

        private void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, RequestGenerationSpecificationTuple input)
        {
            foreach (DiagnosticInfo diagnosticInfo in input.Diagnostics)
            {
                sourceProductionContext.ReportDiagnostic(diagnosticInfo.CreateDiagnostic());
            }

            if (input.RequestGenerationSpecification == null)
            {
                return;
            }

            RequestSourceEmitter requestSourceEmitter = new(sourceProductionContext);
            requestSourceEmitter.Emit(input.RequestGenerationSpecification);
        }
    }
}
