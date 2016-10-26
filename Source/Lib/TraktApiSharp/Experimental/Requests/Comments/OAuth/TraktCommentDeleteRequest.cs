namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;

    internal sealed class TraktCommentDeleteRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktCommentDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments/{id}";
    }
}
