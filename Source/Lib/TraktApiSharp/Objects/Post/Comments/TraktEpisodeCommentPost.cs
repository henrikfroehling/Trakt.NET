namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    /// <summary>An episode comment post.</summary>
    public class TraktEpisodeCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }
    }
}
