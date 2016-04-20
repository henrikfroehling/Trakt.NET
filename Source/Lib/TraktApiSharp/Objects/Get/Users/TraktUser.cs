namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;
    using System;

    public class TraktUser
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "private")]
        public bool Private { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "vip")]
        public bool? VIP { get; set; }

        [JsonProperty(PropertyName = "vip_ep")]
        public bool? VIP_EP { get; set; }

        [JsonProperty(PropertyName = "joined_at")]
        public DateTime? JoinedAt { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "about")]
        public string About { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }

        [JsonProperty(PropertyName = "images")]
        public TraktUserImages Images { get; set; }
    }
}
