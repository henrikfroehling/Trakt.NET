using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class GetRequestSourceEmitter(SourceProductionContext context)
        : RequestSourceEmitterBase<GetRequestGenerationSpecification>(context)
    {
    }
}
