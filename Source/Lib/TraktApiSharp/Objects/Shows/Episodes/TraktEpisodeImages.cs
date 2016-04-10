namespace TraktApiSharp.Objects.Shows.Episodes
{
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of images for a Trakt episode.
    /// </summary>
    public class TraktEpisodeImages
    {
        /// <summary>
        /// A screenshot image set for various sizes.
        /// </summary>
        [JsonProperty(PropertyName = "screenshot")]
        public TraktImageSet Screenshot { get; set; }
    }
}
