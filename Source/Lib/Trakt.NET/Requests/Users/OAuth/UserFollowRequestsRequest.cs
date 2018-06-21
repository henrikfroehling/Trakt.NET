namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Objects.Get.Users;

    internal sealed class UserFollowRequestsRequest : AUsersGetRequest<ITraktUserFollowRequest>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public override string UriTemplate => "users/requests{?extended}";
    }
}
