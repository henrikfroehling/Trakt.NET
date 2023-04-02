namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for an account.</summary>
    public interface ITraktSyncAccountLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when account settings were lastly updated.</summary>
        DateTime? SettingsAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a user lastly received a following.</summary>
        DateTime? FollowedAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a user was lastly followed.</summary>
        DateTime? FollowingAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a follow request was lastly pended.</summary>
        DateTime? PendingAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a follow request lastly occured.</summary>
        DateTime? RequestedAt { get; set; }
    }
}
