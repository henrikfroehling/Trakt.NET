namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Post.Users.Responses;
    using System;

    internal sealed class TraktUserFollowUserRequest : ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>
    {
        internal TraktUserFollowUserRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
