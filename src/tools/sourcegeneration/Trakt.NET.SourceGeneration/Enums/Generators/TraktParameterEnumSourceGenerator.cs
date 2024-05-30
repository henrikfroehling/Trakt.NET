using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    [Generator]
    public sealed class TraktParameterEnumSourceGenerator : TraktEnumSourceGeneratorBase<ParameterEnumGenerationSpecification>, IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context) => InitializeGenerator(context);

        protected override IncrementalValuesProvider<EnumGenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => CombineAndSelectEnumsWithAttribute(context, EnumConstants.FullTraktParameterEnumAttributeName,
                EnumConstants.TrackingNames.InitialParameterEnumExtraction, EnumConstants.TrackingNames.FilteredParameterEnums);

        protected override EnumGenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken)
        {
            TraktEnumDeclarationParser parser = new(enumDeclarationInput.KnownEnumSymbols);

            ParameterEnumGenerationSpecification? enumGenerationSpecification =
                parser.ParseTraktParameterEnumDeclaration(enumDeclarationInput.EnumDeclarationContext.ContextClass, enumDeclarationInput.EnumDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (enumGenerationSpecification, diagnostics);
        }

        protected override EnumSourceEmitterBase<ParameterEnumGenerationSpecification> CreateSourceEmitter(SourceProductionContext context)
            => new ParameterEnumSourceEmitter(context);
    }
}
