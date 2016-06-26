namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Basic;
    using Objects.Get.Users;

    internal class TraktEpisodeWatchingUsersRequest : TraktGetByIdEpisodeRequest<TraktListResult<TraktUser>, TraktUser>
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";

        protected override bool IsListResult => true;
    }
}
