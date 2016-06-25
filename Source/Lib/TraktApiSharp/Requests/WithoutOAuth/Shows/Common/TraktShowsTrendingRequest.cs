namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsTrendingRequest : TraktGetRequest<TraktPaginationListResult<TraktTrendingShow>, TraktTrendingShow>
    {
        internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/trending{?extended,page,limit}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
