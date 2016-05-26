namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsPopularRequest : TraktGetRequest<TraktPaginationListResult<TraktPopularShow>, TraktPopularShow>
    {
        internal TraktShowsPopularRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/popular";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
