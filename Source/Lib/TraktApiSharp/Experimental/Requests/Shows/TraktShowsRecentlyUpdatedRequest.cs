namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedShow>
    {
        public TraktShowsRecentlyUpdatedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";
    }
}
