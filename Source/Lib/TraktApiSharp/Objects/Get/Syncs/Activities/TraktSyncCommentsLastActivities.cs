namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCommentsLastActivities
    {
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }
    }
}
