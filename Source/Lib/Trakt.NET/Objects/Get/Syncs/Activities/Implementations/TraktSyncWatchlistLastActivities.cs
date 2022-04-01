namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for watchlists.</summary>
    public class TraktSyncWatchlistLastActivities : ITraktSyncWatchlistLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a watchlist was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
