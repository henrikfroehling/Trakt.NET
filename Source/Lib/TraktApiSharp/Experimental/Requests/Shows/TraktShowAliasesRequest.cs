namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowAliasesRequest : ATraktListGetByIdRequest<TraktShowAlias>
    {
        internal TraktShowAliasesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/aliases";
    }
}
