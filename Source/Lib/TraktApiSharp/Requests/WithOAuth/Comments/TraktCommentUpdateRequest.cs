namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentUpdateRequest : TraktPostByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse, TraktCommentUpdatePost>
    {
        internal TraktCommentUpdateRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
