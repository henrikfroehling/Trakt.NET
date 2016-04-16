namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects;
    using Objects.Shows.Episodes;

    internal class TraktEpisodeCommentsRequest : TraktGetByIdEpisodeRequest<TraktPaginationListResult<TraktEpisodeComment>, TraktEpisodeComment>
    {
        internal TraktEpisodeCommentsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/comments";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        protected override bool IsListResult => true;
    }
}
