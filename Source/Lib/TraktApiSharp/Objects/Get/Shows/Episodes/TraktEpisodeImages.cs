namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt episode.</summary>
    public class TraktEpisodeImages
    {
        /// <summary>Gets or sets the screenshot image set. See also <seealso cref="TraktImageSet" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "screenshot")]
        [Nullable]
        public TraktImageSet Screenshot { get; set; }
    }
}
