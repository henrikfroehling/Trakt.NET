namespace TraktNET.SourceGeneration.Enums
{
    public sealed record ParameterEnumGenerationSpecification : EnumGenerationSpecification
    {
        public required string ParameterEnumAttributeValue { get; init; }
    }
}
