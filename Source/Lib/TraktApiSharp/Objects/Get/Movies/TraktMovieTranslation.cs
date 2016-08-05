namespace TraktApiSharp.Objects.Get.Movies
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A translation for a Trakt movie.</summary>
    public class TraktMovieTranslation
    {
        /// <summary>Gets or sets the title of the movie translation.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the movie release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        [Nullable]
        public string Overview { get; set; }

        /// <summary>Gets or sets the tagline for the movie release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "tagline")]
        [Nullable]
        public string Tagline { get; set; }

        /// <summary>Gets or sets the two letter language code for the movie translation.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "language")]
        [Nullable]
        public string LanguageCode { get; set; }
    }
}
