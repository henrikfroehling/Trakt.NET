namespace TraktNet.Requests.Recommendations.OAuth
{
    using Objects.Get.Recommendations;

    internal sealed class UserMovieRecommendationsRequest : AUserRecommendationsRequest<ITraktRecommendedMovie>
    {
        public override string UriTemplate => "recommendations/movies{?extended,page,limit,ignore_collected,ignore_watchlisted}";

        public override void Validate() { }
    }
}
