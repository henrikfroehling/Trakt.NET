namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post;
    using Interfaces;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentReplyRequest : ATraktSingleItemPostByIdRequest<TraktCommentPostResponse, TraktCommentReplyPost>, ITraktObjectRequest
    {
        internal TraktCommentReplyRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/replies";
    }
}
