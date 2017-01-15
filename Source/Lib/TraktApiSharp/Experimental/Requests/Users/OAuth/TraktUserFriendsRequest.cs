namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserFriendsRequest : ATraktUsersListGetRequest<TraktUserFriend>
    {
        internal TraktUserFriendsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/friends{?extended}";
    }
}
