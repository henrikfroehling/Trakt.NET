namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Delete;
    using System.Collections.Generic;

    internal class TraktUserUnfollowUserRequest : TraktDeleteRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "user/{username}/follow";
    }
}
