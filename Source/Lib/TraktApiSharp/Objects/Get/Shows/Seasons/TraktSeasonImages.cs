namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt season.</summary>
    public class TraktSeasonImages
    {
        /// <summary>Gets or sets the screenshot image set.</summary>
        [JsonProperty(PropertyName = "poster")]
        public TraktImageSet Poster { get; set; }

        /// <summary>Gets or sets the thumb image.</summary>
        [JsonProperty(PropertyName = "thumb")]
        public TraktImage Thumb { get; set; }
    }
}
