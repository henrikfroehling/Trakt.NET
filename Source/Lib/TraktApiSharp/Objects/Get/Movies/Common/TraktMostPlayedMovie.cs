namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A played Trakt movie.</summary>
    public class TraktMostPlayedMovie
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "watcher_count")]
        public int? WatcherCount { get; set; }

        /// <summary>Gets or sets the play count for the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "play_count")]
        public int? PlayCount { get; set; }

        /// <summary>Gets or sets the collected count for the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "collected_count")]
        public int? CollectedCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
