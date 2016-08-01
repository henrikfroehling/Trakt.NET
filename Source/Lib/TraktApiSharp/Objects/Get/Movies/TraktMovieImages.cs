namespace TraktApiSharp.Objects.Get.Movies
{
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt movie.</summary>
    public class TraktMovieImages
    {
        /// <summary>Gets or sets the fan art image set.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "fanart")]
        public TraktImageSet FanArt { get; set; }

        /// <summary>Gets or sets the poster image set.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "poster")]
        public TraktImageSet Poster { get; set; }

        /// <summary>Gets or sets the loge image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "logo")]
        public TraktImage Logo { get; set; }

        /// <summary>Gets or sets the clear art image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "clearart")]
        public TraktImage ClearArt { get; set; }

        /// <summary>Gets or sets the banner image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "banner")]
        public TraktImage Banner { get; set; }

        /// <summary>Gets or sets the thumb image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "thumb")]
        public TraktImage Thumb { get; set; }
    }
}
