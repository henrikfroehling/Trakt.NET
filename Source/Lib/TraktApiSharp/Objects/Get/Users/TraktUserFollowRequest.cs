namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollowRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "requested_at")]
        public DateTime RequestedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }
    }
}
