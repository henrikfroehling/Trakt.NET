namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A trending Trakt movie.</summary>
    public class TraktTrendingMovie
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "watchers")]
        public int? Watchers { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
