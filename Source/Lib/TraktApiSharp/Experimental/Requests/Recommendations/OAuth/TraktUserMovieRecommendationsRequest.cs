namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Objects.Get.Movies;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserMovieRecommendationsRequest : ATraktUserRecommendationsRequest<TraktMovie>
    {
        public TraktUserMovieRecommendationsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "recommendations/movies{?extended,limit}";
    }
}
