namespace TraktNet.Objects.Post.Comments
{
    using Get.Seasons;

    /// <summary>A season comment post.</summary>
    public interface ITraktSeasonCommentPost : ITraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        ITraktSeason Season { get; set; }
    }
}
