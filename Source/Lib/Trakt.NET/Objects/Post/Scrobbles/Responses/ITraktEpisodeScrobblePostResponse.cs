namespace TraktNet.Objects.Post.Scrobbles.Responses
{
    using Get.Episodes;
    using Get.Shows;

    /// <summary>Represents an episode scrobble response.</summary>
    public interface ITraktEpisodeScrobblePostResponse : ITraktScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was scrobbled.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was scrobbled.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
