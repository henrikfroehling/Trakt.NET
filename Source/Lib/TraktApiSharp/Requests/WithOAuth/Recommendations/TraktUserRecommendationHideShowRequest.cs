namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Delete;

    internal class TraktUserRecommendationHideShowRequest : TraktDeleteByIdRequest
    {
        internal TraktUserRecommendationHideShowRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "recommendations/shows/{id}";
    }
}
