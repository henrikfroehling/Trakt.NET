namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt season.</summary>
    public class TraktSeasonImages
    {
        /// <summary>Gets or sets the screenshot image set. See also <seealso cref="TraktImageSet" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "poster")]
        [Nullable]
        public TraktImageSet Poster { get; set; }

        /// <summary>Gets or sets the thumb image. See also <seealso cref="TraktImage" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "thumb")]
        [Nullable]
        public TraktImage Thumb { get; set; }
    }
}
