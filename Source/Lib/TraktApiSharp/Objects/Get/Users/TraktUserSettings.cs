namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Newtonsoft.Json;

    public class TraktUserSettings
    {
        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }

        [JsonProperty(PropertyName = "account")]
        public TraktAccountSettings Account { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public TraktConnections Connections { get; set; }

        [JsonProperty(PropertyName = "sharing_text")]
        public TraktSharingText SharingText { get; set; }
    }
}
