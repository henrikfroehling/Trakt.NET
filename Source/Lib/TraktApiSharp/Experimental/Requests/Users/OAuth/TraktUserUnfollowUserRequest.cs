namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using System.Collections.Generic;

    internal sealed class TraktUserUnfollowUserRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) {}

        internal string Username { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public string UriTemplate => "users/{username}/follow";
    }
}
