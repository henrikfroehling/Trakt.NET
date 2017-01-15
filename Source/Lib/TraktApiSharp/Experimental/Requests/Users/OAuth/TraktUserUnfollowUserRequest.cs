namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Delete;

    internal sealed class TraktUserUnfollowUserRequest : ATraktNoContentDeleteRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => "users/{username}/follow";
    }
}
