using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class PostRequestSourceEmitter(SourceProductionContext context)
        : RequestSourceEmitterBase<PostRequestGenerationSpecification>(context)
    {
    }
}
