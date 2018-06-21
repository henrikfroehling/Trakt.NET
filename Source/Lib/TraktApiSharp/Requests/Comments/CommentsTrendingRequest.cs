namespace TraktNet.Requests.Comments
{
    internal sealed class CommentsTrendingRequest : ACommentsRequest
    {
        public override string UriTemplate => "comments/trending{/comment_type}{/object_type}{?include_replies,extended,page,limit}";
    }
}
