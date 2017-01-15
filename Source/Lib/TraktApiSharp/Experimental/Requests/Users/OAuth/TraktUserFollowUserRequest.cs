namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Post.Users.Responses;

    internal sealed class TraktUserFollowUserRequest : ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>
    {
        internal TraktUserFollowUserRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => "users/{username}/follow";
    }
}
