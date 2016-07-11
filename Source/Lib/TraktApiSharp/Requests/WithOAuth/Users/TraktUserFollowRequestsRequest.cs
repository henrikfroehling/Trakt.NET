namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserFollowRequestsRequest : TraktGetRequest<IEnumerable<TraktUserFollowRequest>, TraktUserFollowRequest>
    {
        internal TraktUserFollowRequestsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "users/requests{?extended}";

        protected override bool IsListResult => true;
    }
}
