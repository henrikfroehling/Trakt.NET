namespace TraktNet.Objects.Post.Comments.Responses
{
    using Basic;

    public interface ITraktCommentPostResponse : ITraktComment
    {
        ITraktSharing Sharing { get; set; }
    }
}
