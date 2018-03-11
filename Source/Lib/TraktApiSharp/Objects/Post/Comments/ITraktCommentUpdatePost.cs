namespace TraktApiSharp.Objects.Post.Comments
{
    public interface ITraktCommentUpdatePost
    {
        string Comment { get; set; }

        bool? Spoiler { get; set; }
    }
}
