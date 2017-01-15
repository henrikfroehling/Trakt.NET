namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktUserListLikeRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
