namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktGetRequestParser : TraktRequestParser<GetRequestGenerationSpecification>
    {
        internal TraktGetRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsRequestType = _knownRequestSymbols.TraktGetRequestAttributeType != null;

        protected override GetRequestGenerationSpecification? CreateSpecification()
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
