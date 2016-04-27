namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;

    internal class TraktEpisodeWatchingUsersRequest : TraktGetByIdEpisodeRequest<TraktListResult<TraktEpisodeWatchingUser>, TraktEpisodeWatchingUser>
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching";

        protected override bool IsListResult => true;
    }
}
