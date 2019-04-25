namespace TraktNet.Objects.Post.Comments
{
    using Get.Shows;

    /// <summary>A show comment post.</summary>
    public interface ITraktShowCommentPost : ITraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
