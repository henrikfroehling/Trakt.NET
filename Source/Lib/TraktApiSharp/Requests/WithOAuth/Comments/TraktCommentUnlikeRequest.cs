namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Delete;

    internal class TraktCommentUnlikeRequest : TraktDeleteByIdRequest
    {
        internal TraktCommentUnlikeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/like";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;
    }
}
