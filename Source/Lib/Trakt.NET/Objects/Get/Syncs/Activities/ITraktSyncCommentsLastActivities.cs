namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for comments.</summary>
    public interface ITraktSyncCommentsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a comment was lastly liked.</summary>
        DateTime? LikedAt { get; set; }
    }
}
