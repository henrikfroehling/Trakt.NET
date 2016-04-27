namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Newtonsoft.Json;

    public class TraktUserNetworkStatistics
    {
        [JsonProperty(PropertyName = "friends")]
        public int Friends { get; set; }

        [JsonProperty(PropertyName = "followers")]
        public int Followers { get; set; }

        [JsonProperty(PropertyName = "following")]
        public int Following { get; set; }
    }
}
