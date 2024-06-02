using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktPostRequestSourceGenerator : TraktRequestSourceGeneratorBase<PostRequestGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktPostRequestAttributeName,
                RequestConstants.TrackingNames.InitialPostRequestsExtraction, RequestConstants.TrackingNames.FilteredPostRequests);

        protected override RequestGenerationSpecificationTuple ParseClassDeclaration(RequestClassDeclarationSyntaxTuple classDeclarationInput, CancellationToken cancellationToken)
        {
            var parser = new TraktPostRequestParser(classDeclarationInput.KnownRequestSymbols);

            PostRequestGenerationSpecification? requestGenerationSpecification =
                parser.Parse(classDeclarationInput.ClassDeclarationContext.ContextClass,
                    classDeclarationInput.ClassDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (requestGenerationSpecification, diagnostics);
        }

        protected override RequestSourceEmitterBase<PostRequestGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new PostRequestSourceEmitter(context);
    }
}
