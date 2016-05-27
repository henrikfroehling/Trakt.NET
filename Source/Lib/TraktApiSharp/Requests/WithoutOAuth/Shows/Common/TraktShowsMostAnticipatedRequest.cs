namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsMostAnticipatedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostAnticipatedShow>, TraktMostAnticipatedShow>
    {
        internal TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/anticipated{?extended,page,limit}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
