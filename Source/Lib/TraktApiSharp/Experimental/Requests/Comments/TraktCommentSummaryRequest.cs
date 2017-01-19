namespace TraktApiSharp.Experimental.Requests.Comments
{
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentSummaryRequest
    {
        internal TraktCommentSummaryRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public string UriTemplate => "comments/{id}";
    }
}
