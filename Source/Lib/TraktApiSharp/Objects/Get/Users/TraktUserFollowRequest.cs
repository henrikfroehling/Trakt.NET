namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollowRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "requested_at")]
        public DateTime? RequestedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
