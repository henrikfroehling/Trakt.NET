namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for recommendations.</summary>
    public interface ITraktSyncRecommendationsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when recommendations were lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
