namespace TraktApiSharp.Requests.Shows.Episodes
{
    using Objects;
    using Objects.Shows.Episodes;

    internal class TraktEpisodeWatchingUsersRequest : TraktGetByIdEpisodeRequest<TraktListResult<TraktEpisodeWatchingUser>, TraktEpisodeWatchingUser>
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;
    }
}
