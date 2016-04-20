namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncListsLastActivities
    {
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "commented_at")]
        public DateTime? CommentedAt { get; set; }
    }
}
