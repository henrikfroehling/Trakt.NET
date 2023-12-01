namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for notes.</summary>
    public interface ITraktSyncNotesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a user's notes were lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
