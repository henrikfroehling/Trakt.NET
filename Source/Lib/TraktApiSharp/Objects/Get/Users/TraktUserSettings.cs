namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    public class TraktUserSettings
    {
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }

        [JsonProperty(PropertyName = "account")]
        [Nullable]
        public TraktAccountSettings Account { get; set; }

        [JsonProperty(PropertyName = "connections")]
        [Nullable]
        public TraktSharing Connections { get; set; }

        [JsonProperty(PropertyName = "sharing_text")]
        [Nullable]
        public TraktSharingText SharingText { get; set; }
    }
}
