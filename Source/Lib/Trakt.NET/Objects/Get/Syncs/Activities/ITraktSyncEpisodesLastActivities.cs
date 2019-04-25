namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for episodes.</summary>
    public interface ITraktSyncEpisodesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when an episode was lastly watched.</summary>
        DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly added to the watchlist.</summary>
        DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly commented.</summary>
        DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly paused.</summary>
        DateTime? PausedAt { get; set; }
    }
}
