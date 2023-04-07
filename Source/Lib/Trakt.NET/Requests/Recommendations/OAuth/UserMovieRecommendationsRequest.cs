namespace TraktNet.Requests.Recommendations.OAuth
{
    using Objects.Get.Recommendations;

    internal sealed class UserMovieRecommendationsRequest : AUserRecommendationsRequest<ITraktRecommendedMovie>
    {
        public override string UriTemplate => "recommendations/movies{?extended,limit,ignore_collected}";

        public override void Validate() { }
    }
}
