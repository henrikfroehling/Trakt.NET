namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Objects.Post.Users.Responses;
    using System.Collections.Generic;

    internal class TraktUserFollowUserRequest : TraktBodylessPostRequest<TraktUserFollowUserPostResponse, TraktUserFollowUserPostResponse>
    {
        internal TraktUserFollowUserRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/follow";
    }
}
