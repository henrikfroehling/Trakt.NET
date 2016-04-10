namespace TraktApiSharp.Requests.Shows
{
    using Base.Get;
    using Objects;
    using Objects.Shows;

    internal class TraktShowAliasesRequest : TraktGetByIdRequest<TraktListResult<TraktShowAlias>, TraktShowAlias>
    {
        internal TraktShowAliasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/aliases";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
