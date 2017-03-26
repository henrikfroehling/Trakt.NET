namespace TraktApiSharp.Objects.Get.Syncs.Activities.Implementations
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A collection of UTC datetimes of last activities for lists.</summary>
    public class TraktSyncListsLastActivities : ITraktSyncListsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a list was lastly liked.</summary>
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a list was lastly commented.</summary>
        [JsonProperty(PropertyName = "commented_at")]
        public DateTime? CommentedAt { get; set; }
    }
}
