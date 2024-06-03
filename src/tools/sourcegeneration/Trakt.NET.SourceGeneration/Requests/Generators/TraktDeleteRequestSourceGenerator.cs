using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktDeleteRequestSourceGenerator : TraktRequestSourceGeneratorBase, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<RequestGenerationSpecificationTuple> CombineAndSelectRequestsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectRequestsWithAttribute(context, RequestConstants.FullTraktDeleteRequestAttributeName,
                RequestConstants.TrackingNames.InitialDeleteRequestsExtraction, RequestConstants.TrackingNames.FilteredDeleteRequests);
    }
}
