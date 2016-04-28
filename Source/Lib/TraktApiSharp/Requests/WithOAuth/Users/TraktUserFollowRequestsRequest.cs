namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users;

    internal class TraktUserFollowRequestsRequest : TraktGetRequest<TraktListResult<TraktUserFollowRequest>, TraktUserFollowRequest>
    {
        internal TraktUserFollowRequestsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "users/requests";

        protected override bool IsListResult => true;
    }
}
