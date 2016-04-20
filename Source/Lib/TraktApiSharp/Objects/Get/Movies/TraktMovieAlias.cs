namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;

    public class TraktMovieAlias
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }
    }
}
