namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for lists.</summary>
    public interface ITraktSyncListsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a list was lastly liked.</summary>
        DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly commented.</summary>
        DateTime? CommentedAt { get; set; }
    }
}
