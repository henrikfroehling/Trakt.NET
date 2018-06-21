namespace TraktNet.Requests.Comments
{
    internal sealed class CommentsRecentRequest : ACommentsRequest
    {
        public override string UriTemplate => "comments/recent{/comment_type}{/object_type}{?include_replies,extended,page,limit}";
    }
}
