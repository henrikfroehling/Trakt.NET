namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowsRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedShow>, ITraktExtendedInfo
    {
        public TraktShowsRecentlyUpdatedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
