namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowRelatedShowsRequest : ATraktPaginationGetByIdRequest<TraktShow>
    {
        public TraktShowRelatedShowsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/related{?extended,page,limit}";
    }
}
