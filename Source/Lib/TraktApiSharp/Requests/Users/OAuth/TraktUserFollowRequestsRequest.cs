namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using TraktApiSharp.Objects.Get.Users;

    internal sealed class TraktUserFollowRequestsRequest : ATraktUsersGetRequest<ITraktUserFollowRequest>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/requests{?extended}";
    }
}
