namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for movies.</summary>
    public interface ITraktSyncMoviesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a movie was lastly watched.</summary>
        DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly added to the watchlist.</summary>
        DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly commented.</summary>
        DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly paused.</summary>
        DateTime? PausedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly hidden.</summary>
        DateTime? HiddenAt { get; set; }
    }
}
