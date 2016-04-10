namespace TraktApiSharp.Requests.Shows
{
    using Base.Get;
    using Objects;
    using Objects.Shows;

    internal class TraktShowRelatedShowsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktShow>, TraktShow>
    {
        internal TraktShowRelatedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/related";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
