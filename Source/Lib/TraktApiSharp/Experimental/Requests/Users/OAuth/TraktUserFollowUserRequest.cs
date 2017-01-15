namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Post.Users.Responses;
    using System.Collections.Generic;

    internal sealed class TraktUserFollowUserRequest : ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>
    {
        internal TraktUserFollowUserRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override string UriTemplate => "users/{username}/follow";
    }
}
