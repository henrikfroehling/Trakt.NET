namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktUserRecommendationHideMovieRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "recommendations/movies/{id}";
    }
}
