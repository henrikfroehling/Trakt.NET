namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations
{
    using Get.Episodes;
    using Get.Shows;
    using Newtonsoft.Json;

    /// <summary>Represents an episode scrobble response.</summary>
    public class TraktEpisodeScrobblePostResponse : TraktScrobblePostResponse, ITraktEpisodeScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was scrobbled.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was scrobbled.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }
    }
}
