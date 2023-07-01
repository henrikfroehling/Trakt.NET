namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for collaborations.</summary>
    public interface ITraktSyncCollaborationsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a user's collaborations were lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
