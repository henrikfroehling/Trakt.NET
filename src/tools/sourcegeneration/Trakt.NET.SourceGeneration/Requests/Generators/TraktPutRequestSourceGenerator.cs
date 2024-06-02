using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktPutRequestSourceGenerator : TraktRequestSourceGeneratorBase<PutRequestGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktPutRequestAttributeName,
                RequestConstants.TrackingNames.InitialPutRequestsExtraction, RequestConstants.TrackingNames.FilteredPutRequests);

        protected override RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken)
        {
            var parser = new TraktPutRequestParser(classDeclarationInput.KnownRequestSymbols);

            PutRequestGenerationSpecification? requestGenerationSpecification =
                parser.Parse(classDeclarationInput.ClassDeclarationContext.ContextClass,
                    classDeclarationInput.ClassDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (requestGenerationSpecification, diagnostics);
        }

        protected override RequestSourceEmitterBase<PutRequestGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new PutRequestSourceEmitter(context);
    }
}
