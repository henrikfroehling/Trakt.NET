using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktGetRequestSourceGenerator : TraktRequestSourceGeneratorBase, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktGetRequestAttributeName,
                RequestConstants.TrackingNames.InitialGetRequestsExtraction, RequestConstants.TrackingNames.FilteredGetRequests);
    }
}
