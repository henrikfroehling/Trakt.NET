namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    public interface ITraktSyncCommentsLastActivities
    {
        DateTime? LikedAt { get; set; }
    }
}
