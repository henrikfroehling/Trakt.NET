namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Objects.Get.Users;

    internal sealed class TraktUserFollowRequestsRequest : ATraktUsersGetRequest<TraktUserFollowRequest>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/requests{?extended}";
    }
}
