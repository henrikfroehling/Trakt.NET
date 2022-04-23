namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for recommendations.</summary>
    public class TraktSyncRecommendationsLastActivities : ITraktSyncRecommendationsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when recommendations were lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
