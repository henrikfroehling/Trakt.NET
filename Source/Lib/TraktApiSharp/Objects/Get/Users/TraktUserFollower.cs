namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollower
    {
        [JsonProperty(PropertyName = "followed_at")]
        public DateTime? FollowedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
