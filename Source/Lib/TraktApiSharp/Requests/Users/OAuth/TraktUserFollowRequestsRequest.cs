namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;

    internal sealed class TraktUserFollowRequestsRequest : ATraktUsersGetRequest<TraktUserFollowRequest>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/requests{?extended}";
    }
}
