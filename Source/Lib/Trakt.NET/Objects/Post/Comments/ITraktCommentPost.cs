namespace TraktNet.Objects.Post.Comments
{
    using Basic;
    using Requests.Interfaces;

    public interface ITraktCommentPost : IRequestBody
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        bool? Spoiler { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the comment post.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSharing Sharing { get; set; }
    }
}
