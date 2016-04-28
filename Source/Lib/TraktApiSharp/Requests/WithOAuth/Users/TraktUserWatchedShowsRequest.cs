namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users.Watched;
    using System.Collections.Generic;

    internal class TraktUserWatchedShowsRequest : TraktGetRequest<TraktListResult<TraktUserWatchedShowItem>, TraktUserWatchedShowItem>
    {
        internal TraktUserWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/watched/shows";

        protected override bool IsListResult => true;
    }
}
