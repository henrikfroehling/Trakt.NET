namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktUserListLikeRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
