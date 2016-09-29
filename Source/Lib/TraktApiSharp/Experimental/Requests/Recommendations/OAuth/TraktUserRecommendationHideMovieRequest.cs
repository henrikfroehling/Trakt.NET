namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using System;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktNoContentDeleteByIdRequest
    {
        public TraktUserRecommendationHideMovieRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
