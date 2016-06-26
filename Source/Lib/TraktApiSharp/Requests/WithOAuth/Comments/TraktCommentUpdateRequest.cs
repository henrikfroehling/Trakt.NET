namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Put;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentUpdateRequest : TraktPutByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse, TraktCommentUpdatePost>
    {
        internal TraktCommentUpdateRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;
    }
}
