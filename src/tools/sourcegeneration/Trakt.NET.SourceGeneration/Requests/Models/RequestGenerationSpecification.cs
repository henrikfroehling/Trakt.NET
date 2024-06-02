namespace TraktNET.SourceGeneration.Requests
{
    public abstract record RequestGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }

        public required string HttpMethodValue { get; init; }

        public required string UriPath { get; set; }

        public required string OAuthRequirementValue { get; init; }

        public required bool SupportsExtendedInfo { get; set; }

        public required bool SupportsPagination { get; set; }

        public required bool HasOAuthRequirementDefined { get; set; }
    }
}
