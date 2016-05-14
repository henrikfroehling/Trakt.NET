namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Delete;

    internal class TraktUserMovieHideRecommendationRequest : TraktDeleteByIdRequest
    {
        internal TraktUserMovieHideRecommendationRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "recommendations/movies/{id}";
    }
}
