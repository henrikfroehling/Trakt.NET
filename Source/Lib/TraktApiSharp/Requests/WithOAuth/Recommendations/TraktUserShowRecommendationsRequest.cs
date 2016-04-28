namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Recommendations;

    internal class TraktUserShowRecommendationsRequest : TraktGetRequest<TraktListResult<TraktShowRecommendation>, TraktShowRecommendation>
    {
        internal TraktUserShowRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "recommendations/shows";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
