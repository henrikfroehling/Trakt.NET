﻿namespace TraktNet.Requests.Recommendations.OAuth
{
    using Objects.Get.Recommendations;

    internal sealed class UserShowRecommendationsRequest : AUserRecommendationsRequest<ITraktRecommendedShow>
    {
        public override string UriTemplate => "recommendations/shows{?extended,limit,ignore_collected}";

        public override void Validate() { }
    }
}
