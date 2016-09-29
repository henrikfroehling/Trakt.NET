namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using Interfaces;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        public TraktUserRecommendationHideMovieRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
