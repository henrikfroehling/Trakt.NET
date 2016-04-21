namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;

    public class TraktMovieTranslation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }
    }
}
