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

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for watchlists.
        /// See also <seealso cref="ITraktSyncWatchlistLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncWatchlistLastActivities Watchlist { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for favorites.
        /// See also <seealso cref="ITraktSyncFavoritesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncFavoritesLastActivities Favorites { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for recommendations.
        /// See also <seealso cref="ITraktSyncRecommendationsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncRecommendationsLastActivities Recommendations { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for collaborations.
        /// See also <seealso cref="ITraktSyncCollaborationsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncCollaborationsLastActivities Collaborations { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for an account.
        /// See also <seealso cref="ITraktSyncAccountLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncAccountLastActivities Account { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for saved filters.
        /// See also <seealso cref="ITraktSyncSavedFiltersLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncSavedFiltersLastActivities SavedFilters { get; set; }
    }
}
