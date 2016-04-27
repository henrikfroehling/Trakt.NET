namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesPopularRequest : TraktGetRequest<TraktPaginationListResult<TraktMoviesPopularItem>, TraktMoviesPopularItem>
    {
        internal TraktMoviesPopularRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/popular";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
