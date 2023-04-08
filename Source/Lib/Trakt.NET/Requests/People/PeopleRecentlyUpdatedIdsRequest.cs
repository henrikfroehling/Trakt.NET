namespace TraktNet.Requests.People
{
    using Base;

    internal sealed class PeopleRecentlyUpdatedIdsRequest : ARecentlyUpdatedIdsRequest
    {
        public override string UriTemplate => "people/updates/id{/start_date}{?page,limit}";
    }
}
