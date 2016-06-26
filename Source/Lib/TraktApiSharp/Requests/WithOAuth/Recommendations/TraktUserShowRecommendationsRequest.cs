namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows;

    internal class TraktUserShowRecommendationsRequest : TraktGetRequest<TraktPaginationListResult<TraktShow>, TraktShow>
    {
        internal TraktUserShowRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "recommendations/shows{?extended,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
