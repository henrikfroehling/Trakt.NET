namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for notes.</summary>
    public class TraktSyncNotesLastActivities : ITraktSyncNotesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a user's notes were lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
