namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserFollowersRequest : TraktGetRequest<IEnumerable<TraktUserFollower>, TraktUserFollower>
    {
        internal TraktUserFollowersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/followers{?extended}";

        protected override bool IsListResult => true;
    }
}
