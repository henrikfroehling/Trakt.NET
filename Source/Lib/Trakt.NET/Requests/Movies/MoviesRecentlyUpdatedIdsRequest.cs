namespace TraktNet.Requests.Movies
{
    using Base;

    internal sealed class MoviesRecentlyUpdatedIdsRequest : ARecentlyUpdatedIdsRequest
    {
        public override string UriTemplate => "movies/updates/id{/start_date}{?page,limit}";
    }
}
