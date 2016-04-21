namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;

    public class TraktUserSeasonsStatistics
    {
        [JsonProperty(PropertyName = "ratings")]
        public int Ratings { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public int Comments { get; set; }
    }
}
