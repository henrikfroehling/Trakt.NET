namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal sealed class TraktCommentReplyRequest : ATraktSingleItemPostByIdRequest<TraktCommentPostResponse, TraktCommentReplyPost>
    {
        internal TraktCommentReplyRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments/{id}/replies";
    }
}
