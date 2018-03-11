namespace TraktApiSharp.Objects.Post.Comments
{
    using Basic;

    public interface ITraktCommentPost
    {
        string Comment { get; set; }

        bool? Spoiler { get; set; }

        ITraktSharing Sharing { get; set; }
    }
}
