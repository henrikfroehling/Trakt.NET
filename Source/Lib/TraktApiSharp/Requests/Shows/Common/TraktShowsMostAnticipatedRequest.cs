namespace TraktApiSharp.Requests.Shows.Common
{
    using Base.Get;
    using Objects;
    using Objects.Shows.Common;

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
