namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserFollowingRequest : TraktGetRequest<TraktListResult<TraktUserFollower>, TraktUserFollower>
    {
        internal TraktUserFollowingRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/following";

        protected override bool IsListResult => true;
    }
}
