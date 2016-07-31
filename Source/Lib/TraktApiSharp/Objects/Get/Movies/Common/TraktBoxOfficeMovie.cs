namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    /// <summary>A Trakt box office movie.</summary>
    public class TraktBoxOfficeMovie
    {
        /// <summary>Gets or sets the revenue of the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "revenue")]
        public int? Revenue { get; set; }

        /// <summary>Gets or sets the Trakt movie.</summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
