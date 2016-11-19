namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        public TraktEpisodeCommentsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/comments{/sorting}{?page,limit}";
    }
}
