namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonWatchingUsersRequest : TraktGetByIdSeasonRequest<TraktListResult<TraktSeasonWatchingUser>, TraktSeasonWatchingUser>
    {
        internal TraktSeasonWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/watching";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => true;
    }
}
