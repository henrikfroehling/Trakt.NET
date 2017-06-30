namespace TraktApiSharp.Objects.Post.Checkins.Responses.Implementations
{
    using Get.Episodes;
    using Get.Shows;
    using Newtonsoft.Json;

    /// <summary>Represents an episode checkin response.</summary>
    public class TraktEpisodeCheckinPostResponse : TraktCheckinPostResponse, ITraktEpisodeCheckinPostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was checked in.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was checked in.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }
    }
}
