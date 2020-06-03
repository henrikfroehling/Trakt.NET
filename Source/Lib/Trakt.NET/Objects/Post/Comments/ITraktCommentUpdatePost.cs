namespace TraktNet.Objects.Post.Comments
{
    using Requests.Interfaces;

    /// <summary>A comment update post.</summary>
    public interface ITraktCommentUpdatePost : IRequestBody
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        bool? Spoiler { get; set; }
    }
}
