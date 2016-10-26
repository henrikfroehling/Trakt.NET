namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;

    internal sealed class TraktEpisodeCommentPostRequest : ATraktCommentPostRequest<TraktEpisodeCommentPost>
    {
        internal TraktEpisodeCommentPostRequest(TraktClient client) : base(client) { }
    }
}
