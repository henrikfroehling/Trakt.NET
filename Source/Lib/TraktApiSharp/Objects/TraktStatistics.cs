namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;

    public class TraktStatistics
    {
        [JsonProperty(PropertyName = "watchers")]
        public int? Watchers { get; set; }

        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        [JsonProperty(PropertyName = "collectors")]
        public int? Collectors { get; set; }

        [JsonProperty(PropertyName = "collected_episodes")]
        public int? CollectedEpisodes { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public int? Comments { get; set; }

        [JsonProperty(PropertyName = "lists")]
        public int? Lists { get; set; }

        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }
    }
}
