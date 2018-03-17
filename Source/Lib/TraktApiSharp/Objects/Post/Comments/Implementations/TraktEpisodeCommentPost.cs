namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Episodes;

    /// <summary>An episode comment post.</summary>
    public class TraktEpisodeCommentPost : TraktCommentPost, ITraktEpisodeCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        public override string ToJson() => "";

        public override void Validate()
        {
            // TODO
        }
    }
}
