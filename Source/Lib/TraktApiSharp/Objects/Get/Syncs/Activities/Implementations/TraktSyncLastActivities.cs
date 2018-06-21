namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities.</summary>
    public class TraktSyncLastActivities : ITraktSyncLastActivities
    {
        /// <summary>Gets or sets the UTC datetime of the overall last activity.</summary>
        public DateTime? All { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for movies.
        /// See also <seealso cref="ITraktSyncMoviesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncMoviesLastActivities Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for episodes.
        /// See also <seealso cref="ITraktSyncEpisodesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncEpisodesLastActivities Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for shows.
        /// See also <seealso cref="ITraktSyncShowsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncShowsLastActivities Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for seasons.
        /// See also <seealso cref="ITraktSyncSeasonsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncSeasonsLastActivities Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for comments.
        /// See also <seealso cref="ITraktSyncCommentsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncCommentsLastActivities Comments { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for lists.
        /// See also <seealso cref="ITraktSyncListsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncListsLastActivities Lists { get; set; }
    }
}
