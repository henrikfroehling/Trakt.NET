namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktDeleteRequestParser : TraktRequestParser<DeleteRequestGenerationSpecification>
    {
        internal TraktDeleteRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsRequestType = _knownRequestSymbols.TraktDeleteRequestAttributeType != null;

        protected override DeleteRequestGenerationSpecification? CreateSpecification()
            => new()
            {
                Name = _requestClassDeclarationSymbol!.Name,
                Namespace = _requestClassDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HttpMethodValue = _httpMethodValue,
                UriPath = _uriPath,
                OAuthRequirementValue = _requestOAuthRequirementValue,
                SupportsExtendedInfo = _requestSupportsExtendedInfo,
                SupportsPagination = _requestSupportsPagination,
                HasOAuthRequirementDefined = _requestHasOAuthRequirementDefined
            };
    }
}
