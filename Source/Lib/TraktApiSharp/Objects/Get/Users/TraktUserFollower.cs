namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollower
    {
        [JsonProperty(PropertyName = "followed_at")]
        public DateTime? FollowedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }
    }
}
