namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post.Bodyless;

    internal sealed class TraktCommentLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments/{id}/like";
    }
}
