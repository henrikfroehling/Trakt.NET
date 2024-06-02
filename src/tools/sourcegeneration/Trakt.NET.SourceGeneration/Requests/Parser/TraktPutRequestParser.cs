namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktPutRequestParser : TraktRequestParser<PutRequestGenerationSpecification>
    {
        internal TraktPutRequestParser(KnownRequestSymbols knownRequestSymbols) : base(knownRequestSymbols)
            => _compilationContainsRequestType = _knownRequestSymbols.TraktPutRequestAttributeType != null;

        protected override PutRequestGenerationSpecification? CreateSpecification()
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
