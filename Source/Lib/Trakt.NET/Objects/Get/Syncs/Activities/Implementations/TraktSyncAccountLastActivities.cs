namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for an account.</summary>
    public class TraktSyncAccountLastActivities : ITraktSyncAccountLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when account settings were lastly updated.</summary>
        public DateTime? SettingsAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a user lastly received a following.</summary>
        public DateTime? FollowedAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a user was lastly followed.</summary>
        public DateTime? FollowingAt { get; set; }
        
        /// <summary>Gets or sets the UTC datetime, when a follow request was lastly pended.</summary>
        public DateTime? PendingAt { get; set; }
    }
}
