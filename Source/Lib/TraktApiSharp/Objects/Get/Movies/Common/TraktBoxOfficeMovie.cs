namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A Trakt box office movie.</summary>
    public class TraktBoxOfficeMovie
    {
        /// <summary>Gets or sets the revenue of the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "revenue")]
        public int? Revenue { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
