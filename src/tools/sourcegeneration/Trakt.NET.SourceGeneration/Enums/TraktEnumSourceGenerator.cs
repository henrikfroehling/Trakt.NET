using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

using EnumDeclarationSyntaxTuple =
    ((Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax ContextClass, Microsoft.CodeAnalysis.SemanticModel SemanticModel) EnumDeclarationContext,
    TraktNET.SourceGeneration.Enums.KnownEnumSymbols KnownEnumSymbols);

using GenerationSpecificationTuple =
    (TraktNET.SourceGeneration.Enums.EnumGenerationSpecification? EnumGenerationSpecification,
        TraktNET.SourceGeneration.Models.ImmutableEquatableArray<TraktNET.SourceGeneration.Models.DiagnosticInfo> Diagnostics);

namespace TraktNET.SourceGeneration.Enums
{
    [Generator]
    public sealed class TraktEnumSourceGenerator : TraktEnumSourceGeneratorBase, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<GenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectEnumsWithAttribute(context, EnumConstants.FullTraktEnumAttributeName,
                EnumConstants.TrackingNames.InitialEnumExtraction, EnumConstants.TrackingNames.FilteredEnums);

        protected override GenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken)
        {
            TraktEnumDeclarationParser parser = new(enumDeclarationInput.KnownEnumSymbols);

            EnumGenerationSpecification? enumGenerationSpecification =
                parser.ParseTraktEnumDeclaration(enumDeclarationInput.EnumDeclarationContext.ContextClass, enumDeclarationInput.EnumDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (enumGenerationSpecification, diagnostics);
        }
    }
}
