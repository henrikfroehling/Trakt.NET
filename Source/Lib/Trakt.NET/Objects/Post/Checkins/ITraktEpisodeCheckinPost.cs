namespace TraktNet.Objects.Post.Checkins
{
    using Get.Episodes;
    using Get.Shows;

    /// <summary>A checkin post for a Trakt episode.</summary>
    public interface ITraktEpisodeCheckinPost : ITraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the checkin post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the checkin post.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
