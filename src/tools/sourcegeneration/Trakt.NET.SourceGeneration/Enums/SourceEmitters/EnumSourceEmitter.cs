using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Enums
{
    public sealed class EnumSourceEmitter(SourceProductionContext context)
        : EnumSourceEmitterBase<EnumGenerationSpecification>(context)
    {
    }
}
