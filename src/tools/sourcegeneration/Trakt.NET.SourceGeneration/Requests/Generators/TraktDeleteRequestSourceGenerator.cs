using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktDeleteRequestSourceGenerator : TraktRequestSourceGeneratorBase<DeleteRequestGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktDeleteRequestAttributeName,
                RequestConstants.TrackingNames.InitialDeleteRequestsExtraction, RequestConstants.TrackingNames.FilteredDeleteRequests);

        protected override RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken)
        {
            var parser = new TraktDeleteRequestParser(classDeclarationInput.KnownRequestSymbols);

            DeleteRequestGenerationSpecification? requestGenerationSpecification =
                parser.Parse(classDeclarationInput.ClassDeclarationContext.ContextClass,
                    classDeclarationInput.ClassDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (requestGenerationSpecification, diagnostics);
        }

        protected override RequestSourceEmitterBase<DeleteRequestGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new DeleteRequestSourceEmitter(context);
    }
}
