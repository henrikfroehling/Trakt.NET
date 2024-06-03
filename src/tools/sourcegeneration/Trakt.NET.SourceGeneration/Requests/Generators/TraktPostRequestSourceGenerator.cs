using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktPostRequestSourceGenerator : TraktRequestSourceGeneratorBase, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktPostRequestAttributeName,
                RequestConstants.TrackingNames.InitialPostRequestsExtraction, RequestConstants.TrackingNames.FilteredPostRequests);
    }
}
