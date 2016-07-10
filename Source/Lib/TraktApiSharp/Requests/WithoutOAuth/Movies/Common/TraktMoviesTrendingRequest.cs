namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesTrendingRequest : TraktGetRequest<TraktPaginationListResult<TraktTrendingMovie>, TraktTrendingMovie>
    {
        internal TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
