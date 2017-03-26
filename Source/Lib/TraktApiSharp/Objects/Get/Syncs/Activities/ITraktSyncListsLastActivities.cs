namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using System;

    public interface ITraktSyncListsLastActivities
    {
        DateTime? LikedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        DateTime? CommentedAt { get; set; }
    }
}
