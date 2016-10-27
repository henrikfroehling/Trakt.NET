namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedMovie>
    {
        internal TraktMoviesRecentlyUpdatedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/updates{/start_date}{?extended,page,limit}";
    }
}
