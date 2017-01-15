namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Post.Users.Responses;

    internal sealed class TraktUserFollowUserRequest : ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>
    {
        internal TraktUserFollowUserRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/follow";
    }
}
