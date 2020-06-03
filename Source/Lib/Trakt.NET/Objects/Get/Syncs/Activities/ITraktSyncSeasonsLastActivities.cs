namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for seasons.</summary>
    public interface ITraktSyncSeasonsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a season was lastly rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly added to the watchlist.</summary>
        DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly commented.</summary>
        DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly hidden.</summary>
        DateTime? HiddenAt { get; set; }
    }
}
