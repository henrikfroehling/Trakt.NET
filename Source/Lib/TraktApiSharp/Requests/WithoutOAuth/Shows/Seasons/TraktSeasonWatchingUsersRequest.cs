namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktSeasonWatchingUsersRequest : TraktGetByIdSeasonRequest<IEnumerable<TraktUser>, TraktUser>
    {
        internal TraktSeasonWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/watching{?extended}";

        protected override bool IsListResult => true;
    }
}
