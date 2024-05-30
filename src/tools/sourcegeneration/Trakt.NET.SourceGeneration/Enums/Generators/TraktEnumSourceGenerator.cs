using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    [Generator]
    public sealed class TraktEnumSourceGenerator : TraktEnumSourceGeneratorBase<EnumGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<EnumGenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectEnumsWithAttribute(context, EnumConstants.FullTraktEnumAttributeName,
                EnumConstants.TrackingNames.InitialEnumExtraction, EnumConstants.TrackingNames.FilteredEnums);

        protected override EnumGenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken)
        {
            TraktEnumDeclarationParser parser = new(enumDeclarationInput.KnownEnumSymbols);

            EnumGenerationSpecification? enumGenerationSpecification =
                parser.ParseTraktEnumDeclaration(enumDeclarationInput.EnumDeclarationContext.ContextClass, enumDeclarationInput.EnumDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (enumGenerationSpecification, diagnostics);
        }

        protected override EnumSourceEmitterBase<EnumGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new EnumSourceEmitter(context);
    }
}
