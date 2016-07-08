namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Enums;
    using Lists;
    using Newtonsoft.Json;
    using System;

    public class TraktUserLikeItem
    {
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktUserLikeTypeConverter))]
        public TraktUserLikeType? Type { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public TraktComment Comment { get; set; }

        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }
    }
}
