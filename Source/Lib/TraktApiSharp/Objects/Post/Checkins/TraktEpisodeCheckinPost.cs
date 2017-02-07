namespace TraktApiSharp.Objects.Post.Checkins
{
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    /// <summary>A checkin post for a Trakt episode.</summary>
    public class TraktEpisodeCheckinPost : TraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the checkin post.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the checkin post.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
