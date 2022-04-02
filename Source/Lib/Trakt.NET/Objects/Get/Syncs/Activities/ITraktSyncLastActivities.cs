namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities.</summary>
    public interface ITraktSyncLastActivities
    {
        /// <summary>Gets or sets the UTC datetime of the overall last activity.</summary>
        DateTime? All { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for movies.
        /// See also <seealso cref="ITraktSyncMoviesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncMoviesLastActivities Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for shows.
        /// See also <seealso cref="ITraktSyncShowsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncShowsLastActivities Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for seasons.
        /// See also <seealso cref="ITraktSyncSeasonsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncSeasonsLastActivities Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for episodes.
        /// See also <seealso cref="ITraktSyncEpisodesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncEpisodesLastActivities Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for comments.
        /// See also <seealso cref="ITraktSyncCommentsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncCommentsLastActivities Comments { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for lists.
        /// See also <seealso cref="ITraktSyncListsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncListsLastActivities Lists { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for watchlists.
        /// See also <seealso cref="ITraktSyncWatchlistLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncWatchlistLastActivities Watchlist { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for recommendations.
        /// See also <seealso cref="ITraktSyncRecommendationsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncRecommendationsLastActivities Recommendations { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for an account.
        /// See also <seealso cref="ITraktSyncAccountLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncAccountLastActivities Account { get; set; }
    }
}
