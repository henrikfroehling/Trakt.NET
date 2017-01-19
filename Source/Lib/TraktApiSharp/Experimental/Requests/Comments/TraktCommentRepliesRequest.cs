namespace TraktApiSharp.Experimental.Requests.Comments
{
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentRepliesRequest
    {
        internal TraktCommentRepliesRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public string UriTemplate => "comments/{id}/replies{?page,limit}";
    }
}
