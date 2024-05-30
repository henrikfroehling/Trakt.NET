namespace TraktNET.SourceGeneration.Enums
{
    public sealed record EnumMemberGenerationSpecification
    {
        public required string Name { get; init; }

        public required bool HasTraktEnumMemberAttribute { get; init; }

        public required string DisplayName { get; init; }

        public required string JsonValue { get; init; }
    }
}
