namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentLikeRequest : TraktBodylessPostByIdRequest<object, TraktCommentPostResponse>
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/like";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;
    }
}
