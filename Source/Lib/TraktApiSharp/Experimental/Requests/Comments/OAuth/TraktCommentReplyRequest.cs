namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentReplyRequest
    {
        internal TraktCommentReplyRequest(TraktClient client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public string UriTemplate => "comments/{id}/replies";
    }
}
