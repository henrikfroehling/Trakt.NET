namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Seasons;

    /// <summary>A season comment post.</summary>
    public class TraktSeasonCommentPost : TraktCommentPost, ITraktSeasonCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        public ITraktSeason Season { get; set; }
    }
}
