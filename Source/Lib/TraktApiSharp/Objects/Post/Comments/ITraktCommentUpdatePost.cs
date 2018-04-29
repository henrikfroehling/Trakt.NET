namespace TraktApiSharp.Objects.Post.Comments
{
    using Requests.Interfaces;

    public interface ITraktCommentUpdatePost : IRequestBody
    {
        string Comment { get; set; }

        bool? Spoiler { get; set; }
    }
}
