namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserFollowRequestsRequest : ATraktUsersListGetRequest<TraktUserFollowRequest>
    {
        internal TraktUserFollowRequestsRequest(TraktClient client) : base(client) {}

        public new TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public string UriTemplate => "users/requests{?extended}";
    }
}
