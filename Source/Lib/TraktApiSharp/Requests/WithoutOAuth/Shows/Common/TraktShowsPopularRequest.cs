namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsPopularRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsPopularItem>, TraktShowsPopularItem>
    {
        internal TraktShowsPopularRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/popular";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
