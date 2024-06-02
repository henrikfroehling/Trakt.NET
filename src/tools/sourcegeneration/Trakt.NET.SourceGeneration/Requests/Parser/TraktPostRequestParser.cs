namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktPostRequestParser : TraktRequestParser<PostRequestGenerationSpecification>
    {
        internal TraktPostRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsRequestType = _knownRequestSymbols.TraktPostRequestAttributeType != null;

        protected override PostRequestGenerationSpecification? CreateSpecification()
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
