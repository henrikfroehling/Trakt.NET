namespace TraktApiSharp.Requests.Shows.Common
{
    using Base.Get;
    using Objects;
    using Objects.Shows.Common;

    internal class TraktShowsTrendingRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsTrendingItem>, TraktShowsTrendingItem>
    {
        internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/trending";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
