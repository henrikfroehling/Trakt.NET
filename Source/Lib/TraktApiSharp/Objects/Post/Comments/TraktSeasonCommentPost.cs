namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows.Seasons;
    using Newtonsoft.Json;

    /// <summary>A season comment post.</summary>
    public class TraktSeasonCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }
    }
}
