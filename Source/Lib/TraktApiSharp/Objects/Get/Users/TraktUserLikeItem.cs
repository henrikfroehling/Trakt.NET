namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
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
        [Nullable]
        public TraktUserLikeType Type { get; set; }

        [JsonProperty(PropertyName = "comment")]
        [Nullable]
        public TraktComment Comment { get; set; }

        [JsonProperty(PropertyName = "list")]
        [Nullable]
        public TraktList List { get; set; }
    }
}
