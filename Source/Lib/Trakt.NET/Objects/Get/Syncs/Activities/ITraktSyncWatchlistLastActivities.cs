namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for watchlists.</summary>
    public interface ITraktSyncWatchlistLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a watchlist was lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
