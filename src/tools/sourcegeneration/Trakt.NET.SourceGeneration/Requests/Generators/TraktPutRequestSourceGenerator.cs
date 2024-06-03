using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktPutRequestSourceGenerator : TraktRequestSourceGeneratorBase, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktPutRequestAttributeName,
                RequestConstants.TrackingNames.InitialPutRequestsExtraction, RequestConstants.TrackingNames.FilteredPutRequests);
    }
}
