namespace TraktNET.SourceGeneration.Enums
{
    public sealed record EnumGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }

        public required bool HasFlagsAttribute { get; init; }

        public required bool HasTraktParameterEnumAttribute { get; init; }

        public required string ParameterEnumAttributeValue { get; init; }

        public required List<EnumMemberGenerationSpecification> Members { get; init; }
    }
}
