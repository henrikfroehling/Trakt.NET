using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktGetRequestSourceGenerator : TraktRequestSourceGeneratorBase<GetRequestGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktGetRequestAttributeName,
                RequestConstants.TrackingNames.InitialGetRequestsExtraction, RequestConstants.TrackingNames.FilteredGetRequests);

        protected override RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken)
        {
            var parser = new TraktGetRequestParser(classDeclarationInput.KnownRequestSymbols);

            GetRequestGenerationSpecification? requestGenerationSpecification =
                parser.Parse(classDeclarationInput.ClassDeclarationContext.ContextClass,
                    classDeclarationInput.ClassDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (requestGenerationSpecification, diagnostics);
        }

        protected override RequestSourceEmitterBase<GetRequestGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new GetRequestSourceEmitter(context);
    }
}
