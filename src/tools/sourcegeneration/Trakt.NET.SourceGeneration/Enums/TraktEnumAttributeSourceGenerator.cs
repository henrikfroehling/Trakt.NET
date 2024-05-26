using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace TraktNET.SourceGeneration.Enums
{
    [Generator]
    public sealed class TraktEnumAttributeSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(EnumConstants.GeneratedTraktEnumAttributeFilename,
                SourceText.From(EnumConstants.TraktEnumAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(EnumConstants.GeneratedTraktEnumMemberJsonValueAttributeFilename,
                SourceText.From(EnumConstants.TraktEnumMemberJsonValueAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(EnumConstants.GeneratedTraktParameterEnumAttributeFilename,
                SourceText.From(EnumConstants.TraktParameterEnumAttribute, Encoding.UTF8)));
        }
    }
}
