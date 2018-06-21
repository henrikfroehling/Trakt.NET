namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for seasons.</summary>
    public class TraktSyncSeasonsLastActivities : ITraktSyncSeasonsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a season was lastly rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly added to the watchlist.</summary>
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
