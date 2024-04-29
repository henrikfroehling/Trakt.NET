namespace TraktNet.Requests.Recommendations.OAuth
{
    using Objects.Get.Recommendations;

    internal sealed class UserShowRecommendationsRequest : AUserRecommendationsRequest<ITraktRecommendedShow>
    {
        public override string UriTemplate => "recommendations/shows{?extended,page,limit,ignore_collected,ignore_watchlisted}";

        public override void Validate() { }
    }
}
