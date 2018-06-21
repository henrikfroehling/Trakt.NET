namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Episodes;
    using Movies;
    using Shows;
    using System;

    /// <summary>Contains information about a movie or an episode a Trakt user is currently watching.</summary>
    public class TraktUserWatchingItem : ITraktUserWatchingItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie or episode started.</summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie or episode expires.</summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the action type for the movie or episode.
        /// See also <seealso cref="TraktHistoryActionType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktHistoryActionType Action { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this watching item contains.
        /// See also <seealso cref="TraktSyncType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktSyncType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode Episode { get; set; }
    }
}
