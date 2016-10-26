namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;

    internal sealed class TraktListCommentPostRequest : ATraktCommentPostRequest<TraktListCommentPost>
    {
        internal TraktListCommentPostRequest(TraktClient client) : base(client) { }
    }
}
