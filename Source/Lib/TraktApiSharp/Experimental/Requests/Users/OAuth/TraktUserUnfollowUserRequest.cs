namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Delete;

    internal sealed class TraktUserUnfollowUserRequest : ATraktNoContentDeleteRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/follow";
    }
}
