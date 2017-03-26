namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using System;

    public interface ITraktSyncShowsLastActivities
    {
        DateTime? RatedAt { get; set; }

        DateTime? WatchlistedAt { get; set; }

        DateTime? CommentedAt { get; set; }

        DateTime? HiddenAt { get; set; }
    }
}
