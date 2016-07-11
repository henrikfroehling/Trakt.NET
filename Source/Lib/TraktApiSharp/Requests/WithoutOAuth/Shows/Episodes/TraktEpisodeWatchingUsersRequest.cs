namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktEpisodeWatchingUsersRequest : TraktGetByIdEpisodeRequest<IEnumerable<TraktUser>, TraktUser>
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";

        protected override bool IsListResult => true;
    }
}
