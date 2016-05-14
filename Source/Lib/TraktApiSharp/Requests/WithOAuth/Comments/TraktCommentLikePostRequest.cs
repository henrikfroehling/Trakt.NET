namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentLikePostRequest : TraktBodylessPostByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse>
    {
        internal TraktCommentLikePostRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/like";
    }
}
