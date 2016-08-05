namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    public class TraktUserFriend
    {
        [JsonProperty(PropertyName = "friends_at")]
        public DateTime? FriendsAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
