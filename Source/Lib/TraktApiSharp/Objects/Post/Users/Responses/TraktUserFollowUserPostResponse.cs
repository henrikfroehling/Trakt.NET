namespace TraktApiSharp.Objects.Post.Users.Responses
{
    using Attributes;
    using Get.Users;
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollowUserPostResponse
    {
        [JsonProperty(PropertyName = "approved_at")]
        public DateTime? ApprovedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
