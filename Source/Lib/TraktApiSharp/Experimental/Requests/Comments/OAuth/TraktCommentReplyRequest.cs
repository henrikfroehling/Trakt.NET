namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentReplyRequest : ATraktSingleItemPostByIdRequest<TraktCommentPostResponse, TraktCommentReplyPost>
    {
        internal TraktCommentReplyRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/replies";
    }
}
