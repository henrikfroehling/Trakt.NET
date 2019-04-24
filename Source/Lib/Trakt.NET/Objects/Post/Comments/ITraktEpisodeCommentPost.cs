namespace TraktNet.Objects.Post.Comments
{
    using Get.Episodes;

    /// <summary>An episode comment post.</summary>
    public interface ITraktEpisodeCommentPost : ITraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        ITraktEpisode Episode { get; set; }
    }
}
