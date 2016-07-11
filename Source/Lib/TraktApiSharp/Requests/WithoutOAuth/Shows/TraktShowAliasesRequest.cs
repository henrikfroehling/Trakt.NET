namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System.Collections.Generic;

    internal class TraktShowAliasesRequest : TraktGetByIdRequest<IEnumerable<TraktShowAlias>, TraktShowAlias>
    {
        internal TraktShowAliasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/aliases";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
