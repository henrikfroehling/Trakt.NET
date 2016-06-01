namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Recommendations;

    internal class TraktUserShowRecommendationsRequest : TraktGetRequest<TraktPaginationListResult<TraktShowRecommendation>, TraktShowRecommendation>
    {
        internal TraktUserShowRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "recommendations/shows{?extended,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
