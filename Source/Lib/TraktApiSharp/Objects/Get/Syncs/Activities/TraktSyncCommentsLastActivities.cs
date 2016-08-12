namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A collection of UTC datetimes of last activities for comments.</summary>
    public class TraktSyncCommentsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a comment was lastly liked.</summary>
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }
    }
}
