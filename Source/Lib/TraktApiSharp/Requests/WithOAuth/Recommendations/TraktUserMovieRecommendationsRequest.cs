namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies;

    internal class TraktUserMovieRecommendationsRequest : TraktGetRequest<TraktPaginationListResult<TraktMovie>, TraktMovie>
    {
        internal TraktUserMovieRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "recommendations/movies{?extended,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
