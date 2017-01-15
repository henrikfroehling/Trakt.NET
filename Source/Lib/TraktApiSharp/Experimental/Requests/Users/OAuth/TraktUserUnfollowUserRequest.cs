namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Delete;
    using System.Collections.Generic;

    internal sealed class TraktUserUnfollowUserRequest : ATraktNoContentDeleteRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override string UriTemplate => "users/{username}/follow";
    }
}
