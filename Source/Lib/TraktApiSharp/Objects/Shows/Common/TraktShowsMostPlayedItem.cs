namespace TraktApiSharp.Objects.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktShowsMostPlayedItem
    {
        [JsonProperty(PropertyName = "watcher_count")]
        public int? WatcherCount { get; set; }

        [JsonProperty(PropertyName = "play_count")]
        public int? PlayCount { get; set; }

        [JsonProperty(PropertyName = "collected_count")]
        public int? CollectedCount { get; set; }

        [JsonProperty(PropertyName = "collector_count")]
        public int? CollectorCount { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
