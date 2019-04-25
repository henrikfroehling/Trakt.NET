namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for shows.</summary>
    public interface ITraktSyncShowsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a show was lastly rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly added to the watchlist.</summary>
        DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly commented.</summary>
        DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly hidden.</summary>
        DateTime? HiddenAt { get; set; }
    }
}
