namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using Interfaces;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideShowRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        public TraktUserRecommendationHideShowRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
