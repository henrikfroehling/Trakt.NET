namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Put;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentUpdateRequest : ATraktSingleItemPutByIdRequest<TraktCommentPostResponse, TraktCommentUpdatePost>
    {
        internal TraktCommentUpdateRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}";
    }
}
