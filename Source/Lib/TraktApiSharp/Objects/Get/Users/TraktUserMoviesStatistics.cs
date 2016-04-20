namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;

    public class TraktUserMoviesStatistics
    {
        [JsonProperty(PropertyName = "plays")]
        public int Plays { get; set; }

        [JsonProperty(PropertyName = "watched")]
        public int Watched { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        [JsonProperty(PropertyName = "collected")]
        public int Collected { get; set; }

        [JsonProperty(PropertyName = "ratings")]
        public int Ratings { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public int Comments { get; set; }
    }
}
