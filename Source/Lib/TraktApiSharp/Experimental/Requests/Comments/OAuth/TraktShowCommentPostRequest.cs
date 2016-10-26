namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;

    internal sealed class TraktShowCommentPostRequest : ATraktCommentPostRequest<TraktShowCommentPost>
    {
        internal TraktShowCommentPostRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments";
    }
}
