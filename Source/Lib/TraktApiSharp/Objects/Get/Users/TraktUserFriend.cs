namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;
    using System;

    public class TraktUserFriend
    {
        [JsonProperty(PropertyName = "friends_at")]
        public DateTime? FriendsAt { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }
    }
}
