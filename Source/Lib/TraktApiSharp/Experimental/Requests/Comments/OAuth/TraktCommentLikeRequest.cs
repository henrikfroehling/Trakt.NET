namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post.Bodyless;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/like";
    }
}
