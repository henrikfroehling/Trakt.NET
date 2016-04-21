namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Basic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of images for a Trakt season.
    /// </summary>
    public class TraktSeasonImages
    {
        /// <summary>
        /// A poster image set for various sizes.
        /// </summary>
        [JsonProperty(PropertyName = "poster")]
        public TraktImageSet Poster { get; set; }

        /// <summary>
        /// A thumbnail image.
        /// </summary>
        [JsonProperty(PropertyName = "thumb")]
        public TraktImage Thumb { get; set; }
    }
}
