namespace TraktNET.SourceGeneration.Enums
{
    public record EnumGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }

        public required bool HasFlagsAttribute { get; init; }

        public required List<EnumMemberGenerationSpecification> Members { get; init; }
    }
}
