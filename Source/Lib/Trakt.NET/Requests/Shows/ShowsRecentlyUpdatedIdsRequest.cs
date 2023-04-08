namespace TraktNet.Requests.Shows
{
    using Base;

    internal class ShowsRecentlyUpdatedIdsRequest : ARecentlyUpdatedIdsRequest
    {
        public override string UriTemplate => "shows/updates/id{/start_date}{?page,limit}";
    }
}
