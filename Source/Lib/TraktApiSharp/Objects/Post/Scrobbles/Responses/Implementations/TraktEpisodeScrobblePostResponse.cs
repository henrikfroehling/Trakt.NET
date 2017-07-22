namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations
{
    using Get.Episodes;
    using Get.Shows;

    /// <summary>Represents an episode scrobble response.</summary>
    public class TraktEpisodeScrobblePostResponse : TraktScrobblePostResponse, ITraktEpisodeScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was scrobbled.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was scrobbled.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
