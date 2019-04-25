namespace TraktNet.Objects.Post.Comments.Responses
{
    using Basic;

    /// <summary>Represents a comment post response.</summary>
    public interface ITraktCommentPostResponse : ITraktComment
    {
        /// <summary>
        /// Gets or sets the sharing options of the comment post response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSharing Sharing { get; set; }
    }
}
