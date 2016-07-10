namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users;

    internal class TraktUserFollowRequestsRequest : TraktGetRequest<TraktListResult<TraktUserFollowRequest>, TraktUserFollowRequest>
    {
        internal TraktUserFollowRequestsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "users/requests{?extended}";

        protected override bool IsListResult => true;
    }
}
