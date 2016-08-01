namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt episode.</summary>
    public class TraktEpisodeImages
    {
        /// <summary>Gets or sets the screenshot image set.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "screenshot")]
        public TraktImageSet Screenshot { get; set; }
    }
}
