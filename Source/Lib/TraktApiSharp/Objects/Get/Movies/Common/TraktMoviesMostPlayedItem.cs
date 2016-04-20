namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    public class TraktMoviesMostPlayedItem
    {
        [JsonProperty(PropertyName = "watcher_count")]
        public int WatcherCount { get; set; }

        [JsonProperty(PropertyName = "play_count")]
        public int PlayCount { get; set; }

        [JsonProperty(PropertyName = "collected_count")]
        public int CollectedCount { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
