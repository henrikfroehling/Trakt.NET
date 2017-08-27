namespace TraktApiSharp.Requests.Recommendations.OAuth
{
    using Objects.Get.Movies;

    internal sealed class UserMovieRecommendationsRequest : AUserRecommendationsRequest<ITraktMovie>
    {
        public override string UriTemplate => "recommendations/movies{?extended,limit}";

        public override void Validate() { }
    }
}
