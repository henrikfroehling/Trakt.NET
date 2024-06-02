using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class DeleteRequestSourceEmitter(SourceProductionContext context)
        : RequestSourceEmitterBase<DeleteRequestGenerationSpecification>(context)
    {
    }
}
