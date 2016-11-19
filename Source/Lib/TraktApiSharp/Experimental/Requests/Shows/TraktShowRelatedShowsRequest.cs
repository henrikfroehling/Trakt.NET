namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowRelatedShowsRequest : ATraktPaginationGetByIdRequest<TraktShow>, ITraktObjectRequest
    {
        public TraktShowRelatedShowsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/related{?extended,page,limit}";
    }
}
