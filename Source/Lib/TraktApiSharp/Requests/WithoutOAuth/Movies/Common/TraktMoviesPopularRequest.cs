namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesPopularRequest : TraktGetRequest<TraktPaginationListResult<TraktPopularMovie>, TraktPopularMovie>
    {
        internal TraktMoviesPopularRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/popular{?extended,page,limit}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
