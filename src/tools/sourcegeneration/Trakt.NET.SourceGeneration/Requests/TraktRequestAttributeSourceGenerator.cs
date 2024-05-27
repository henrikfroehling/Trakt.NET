using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace TraktNET.SourceGeneration.Requests
{
    [Generator]
    public sealed class TraktRequestAttributeSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktOAuthRequirementFilename,
                SourceText.From(RequestConstants.TraktOAuthRequirement, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktRequestAttributeFilename,
                SourceText.From(RequestConstants.TraktRequestAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktGetRequestAttributeFilename,
                SourceText.From(RequestConstants.TraktGetRequestAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktPostRequestAttributeFilename,
                SourceText.From(RequestConstants.TraktPostRequestAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktPutRequestAttributeFilename,
                SourceText.From(RequestConstants.TraktPutRequestAttribute, Encoding.UTF8)));

            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(RequestConstants.GeneratedTraktDeleteRequestAttributeFilename,
                SourceText.From(RequestConstants.TraktDeleteRequestAttribute, Encoding.UTF8)));
        }
    }
}
