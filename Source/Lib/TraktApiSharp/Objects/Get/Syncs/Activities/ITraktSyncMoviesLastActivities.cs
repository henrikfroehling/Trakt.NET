namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using System;

    public interface ITraktSyncMoviesLastActivities
    {
        DateTime? WatchedAt { get; set; }

        DateTime? CollectedAt { get; set; }

        DateTime? RatedAt { get; set; }

        DateTime? WatchlistedAt { get; set; }

        DateTime? CommentedAt { get; set; }

        DateTime? PausedAt { get; set; }

        DateTime? HiddenAt { get; set; }
    }
}
