namespace TraktNet.Objects.Post.Checkins.Responses
{
    using Get.Episodes;
    using Get.Shows;

    /// <summary>Represents an episode checkin response.</summary>
    public interface ITraktEpisodeCheckinPostResponse : ITraktCheckinPostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt episode, which was checked in.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the episode, which was checked in.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
