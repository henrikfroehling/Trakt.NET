namespace TraktApiSharp.Objects.Post.Users.Responses
{
    using Get.Users;
    using Newtonsoft.Json;
    using System;

    public class TraktUserFollowUserPostResponse
    {
        [JsonProperty(PropertyName = "approved_at")]
        public DateTime? ApprovedAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }
    }
}
