namespace TraktApiSharp.Objects.Shows
{
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of images for a Trakt show.
    /// </summary>
    public class TraktShowImages
    {
        /// <summary>
        /// A fanart image set for various sizes.
        /// </summary>
        [JsonProperty(PropertyName = "fanart")]
        public TraktImageSet FanArt { get; set; }

        /// <summary>
        /// A poster image set for various sizes.
        /// </summary>
        [JsonProperty(PropertyName = "poster")]
        public TraktImageSet Poster { get; set; }

        /// <summary>
        /// A logo image.
        /// </summary>
        [JsonProperty(PropertyName = "logo")]
        public TraktImage Logo { get; set; }

        /// <summary>
        /// A clearart image.
        /// </summary>
        [JsonProperty(PropertyName = "clearart")]
        public TraktImage ClearArt { get; set; }

        /// <summary>
        /// A banner image.
        /// </summary>
        [JsonProperty(PropertyName = "banner")]
        public TraktImage Banner { get; set; }

        /// <summary>
        /// A thumbnail image.
        /// </summary>
        [JsonProperty(PropertyName = "thumb")]
        public TraktImage Thumb { get; set; }
    }
}
