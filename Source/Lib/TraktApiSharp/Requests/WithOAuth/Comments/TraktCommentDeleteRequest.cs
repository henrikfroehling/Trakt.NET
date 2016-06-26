namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Delete;

    internal class TraktCommentDeleteRequest : TraktDeleteByIdRequest
    {
        internal TraktCommentDeleteRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;
    }
}
