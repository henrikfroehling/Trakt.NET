namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>, ITraktObjectRequest
    {
        internal TraktEpisodeCommentsRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        internal TraktCommentSortOrder Sorting { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/comments{/sorting}{?page,limit}";
    }
}
