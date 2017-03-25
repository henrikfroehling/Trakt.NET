namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Get.Episodes;
    using Get.Shows;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;

    /// <summary>Represents an episode checkin response.</summary>
    public class TraktEpisodeCheckinPostResponse : TraktCheckinPostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was checked in.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was checked in.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
