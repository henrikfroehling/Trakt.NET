namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A collection of UTC datetimes of last activities.</summary>
    public class TraktSyncLastActivities
    {
        /// <summary>Gets or sets the UTC datetime of the overall last activity.</summary>
        [JsonProperty(PropertyName = "all")]
        public DateTime? All { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for movies.
        /// See also <seealso cref="TraktSyncMoviesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public TraktSyncMoviesLastActivities Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for episodes.
        /// See also <seealso cref="TraktSyncEpisodesLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public TraktSyncEpisodesLastActivities Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for shows.
        /// See also <seealso cref="TraktSyncShowsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public TraktSyncShowsLastActivities Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for seasons.
        /// See also <seealso cref="TraktSyncSeasonsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public TraktSyncSeasonsLastActivities Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for comments.
        /// See also <seealso cref="TraktSyncCommentsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "comments")]
        public TraktSyncCommentsLastActivities Comments { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for lists.
        /// See also <seealso cref="TraktSyncListsLastActivities" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lists")]
        public TraktSyncListsLastActivities Lists { get; set; }
    }
}
