namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for saved filters.</summary>
    public interface ITraktSyncSavedFiltersLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a saved filter was lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
