namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentReplyPostRequest : TraktPostByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse, TraktCommentReplyPost>
    {
        internal TraktCommentReplyPostRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/replies";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
