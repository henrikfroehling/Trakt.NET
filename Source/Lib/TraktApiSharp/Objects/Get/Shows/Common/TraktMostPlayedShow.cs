namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A played Trakt show.</summary>
    public class TraktMostPlayedShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "watcher_count")]
        public int? WatcherCount { get; set; }

        /// <summary>Gets or sets the play count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "play_count")]
        public int? PlayCount { get; set; }

        /// <summary>Gets or sets the collected count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "collected_count")]
        public int? CollectedCount { get; set; }

        /// <summary>Gets or sets the collectors count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "collector_count")]
        public int? CollectorCount { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
