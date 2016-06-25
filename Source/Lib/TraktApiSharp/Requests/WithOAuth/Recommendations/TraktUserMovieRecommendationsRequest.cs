namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Recommendations;

    internal class TraktUserMovieRecommendationsRequest : TraktGetRequest<TraktPaginationListResult<TraktMovieRecommendation>, TraktMovieRecommendation>
    {
        internal TraktUserMovieRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "recommendations/movies{?extended,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
