namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCommentsLastActivities
    {
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }
    }
}
