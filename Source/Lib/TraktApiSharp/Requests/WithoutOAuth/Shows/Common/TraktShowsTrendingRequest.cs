namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsTrendingRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsTrendingItem>, TraktShowsTrendingItem>
    {
        internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/trending";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
