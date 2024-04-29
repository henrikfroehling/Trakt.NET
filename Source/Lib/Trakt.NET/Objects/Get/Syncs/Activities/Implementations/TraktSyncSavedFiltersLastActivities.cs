namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for saved filters.</summary>
    public class TraktSyncSavedFiltersLastActivities : ITraktSyncSavedFiltersLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a saved filter was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
