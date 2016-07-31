namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;

    /// <summary>An alias for a Trakt movie.</summary>
    public class TraktMovieAlias
    {
        /// <summary>Gets or sets the title of the movie alias.</summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the movie alias.</summary>
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }
    }
}
