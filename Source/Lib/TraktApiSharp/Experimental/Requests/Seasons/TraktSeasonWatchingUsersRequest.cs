namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>
    {
        public TraktSeasonWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}/watching{?extended}";
    }
}
