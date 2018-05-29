namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for episodes.</summary>
    public class TraktSyncEpisodesLastActivities : ITraktSyncEpisodesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when an episode was lastly watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly added to the watchlist.</summary>
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly paused.</summary>
        public DateTime? PausedAt { get; set; }
    }
}
