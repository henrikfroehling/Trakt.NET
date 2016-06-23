namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentPostRequest<TRequest> : TraktPostRequest<TraktCommentPostResponse, TraktCommentPostResponse, TRequest> where TRequest : TraktCommentPost
    {
        internal TraktCommentPostRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments";
    }
}
