namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;

    /// <summary>A translation for a Trakt movie.</summary>
    public class TraktMovieTranslation
    {
        /// <summary>Gets or sets the title of the movie translation.</summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the movie release.</summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>Gets or sets the tagline for the movie release.</summary>
        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

        /// <summary>Gets or sets the two letter language code for the movie translation.</summary>
        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }
    }
}
