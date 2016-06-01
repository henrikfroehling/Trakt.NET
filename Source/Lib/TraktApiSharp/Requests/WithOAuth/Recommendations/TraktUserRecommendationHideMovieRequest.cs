namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Delete;

    internal class TraktUserRecommendationHideMovieRequest : TraktDeleteByIdRequest
    {
        internal TraktUserRecommendationHideMovieRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "recommendations/movies/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}
