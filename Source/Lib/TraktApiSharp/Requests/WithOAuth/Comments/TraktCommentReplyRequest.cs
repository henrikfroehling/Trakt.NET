namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentReplyRequest : TraktPostByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse, TraktCommentReplyPost>
    {
        internal TraktCommentReplyRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/replies";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;
    }
}
