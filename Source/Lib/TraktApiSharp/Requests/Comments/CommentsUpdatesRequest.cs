namespace TraktNet.Requests.Comments
{
    internal sealed class CommentsUpdatesRequest : ACommentsRequest
    {
        public override string UriTemplate => "comments/updates{/comment_type}{/object_type}{?include_replies,extended,page,limit}";
    }
}
