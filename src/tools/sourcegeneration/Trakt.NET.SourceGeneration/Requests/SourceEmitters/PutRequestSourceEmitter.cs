using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class PutRequestSourceEmitter(SourceProductionContext context)
        : RequestSourceEmitterBase<PutRequestGenerationSpecification>(context)
    {
    }
}
