namespace TraktNet.Objects.Post.Comments
{
    using Get.Lists;

    /// <summary>A list comment post.</summary>
    public interface ITraktListCommentPost : ITraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="ITraktList" />.
        /// </summary>
        ITraktList List { get; set; }
    }
}
