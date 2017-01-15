namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserFollowRequestsRequest : ATraktUsersListGetRequest<TraktUserFollowRequest>
    {
        internal TraktUserFollowRequestsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/requests{?extended}";
    }
}
