namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for lists.</summary>
    public class TraktSyncListsLastActivities : ITraktSyncListsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a list was lastly liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }
    }
}
