namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;
    using Objects.Get.Users;

    internal class TraktSeasonWatchingUsersRequest : TraktGetByIdSeasonRequest<TraktListResult<TraktUser>, TraktUser>
    {
        internal TraktSeasonWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/watching{?extended}";

        protected override bool IsListResult => true;
    }
}
