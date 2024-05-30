namespace TraktNET.SourceGeneration.Requests
{
    public abstract record RequestGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }
    }
}
