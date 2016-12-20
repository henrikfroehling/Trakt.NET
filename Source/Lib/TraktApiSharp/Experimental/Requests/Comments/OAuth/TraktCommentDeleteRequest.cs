namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentDeleteRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        internal TraktCommentDeleteRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}";
    }
}
