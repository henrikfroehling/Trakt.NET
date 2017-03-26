namespace TraktApiSharp.Objects.Get.Syncs.Activities.Implementations
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A collection of UTC datetimes of last activities for comments.</summary>
    public class TraktSyncCommentsLastActivities : ITraktSyncCommentsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a comment was lastly liked.</summary>
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }
    }
}
