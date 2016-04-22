namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsMostAnticipatedRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsMostAnticipatedItem>, TraktShowsMostAnticipatedItem>
    {
        internal TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/anticipated";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
