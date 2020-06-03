namespace TraktNet.Objects.Get.Syncs.Playback
{
    using Enums;
    using Episodes;
    using Movies;
    using Shows;
    using System;

    /// <summary>Contains information about a Trakt playback progress, including the corresponding movie or episode.</summary>
    public interface ITraktSyncPlaybackProgressItem
    {
        /// <summary>Gets or sets the id of this progress item.</summary>
        uint Id { get; set; }

        /// <summary>
        /// Gets or sets a value between 0 and 100 representing the watched progress percentage
        /// of the movie or episode.
        /// </summary>
        float? Progress { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the watched movie or episode was paused.</summary>
        DateTime? PausedAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this progress item contains.
        /// See also <seealso cref="TraktSyncType" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktSyncType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }
    }
}
