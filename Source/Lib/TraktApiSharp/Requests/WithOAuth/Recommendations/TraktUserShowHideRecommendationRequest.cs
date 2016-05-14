namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Delete;

    internal class TraktUserShowHideRecommendationRequest : TraktDeleteByIdRequest
    {
        internal TraktUserShowHideRecommendationRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "recommendations/shows/{id}";
    }
}
