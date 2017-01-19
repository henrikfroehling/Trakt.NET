namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    internal abstract class ATraktCommentPostRequest<TRequestBody>
    {
        internal ATraktCommentPostRequest(TraktClient client) { }

        public string UriTemplate => "comments";
    }
}
