namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for comments.</summary>
    public class TraktSyncCommentsLastActivities : ITraktSyncCommentsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a comment was lastly liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a comment was lastly blocked.</summary>
        public DateTime? BlockedAt { get; set; }
    }
}
