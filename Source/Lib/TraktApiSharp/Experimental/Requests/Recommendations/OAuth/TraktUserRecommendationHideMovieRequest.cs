namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        internal TraktUserRecommendationHideMovieRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "recommendations/movies/{id}";
    }
}
