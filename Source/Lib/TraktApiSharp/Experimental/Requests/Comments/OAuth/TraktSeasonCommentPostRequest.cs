namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;

    internal sealed class TraktSeasonCommentPostRequest : ATraktCommentPostRequest<TraktSeasonCommentPost>
    {
        internal TraktSeasonCommentPostRequest(TraktClient client) : base(client) { }
    }
}
