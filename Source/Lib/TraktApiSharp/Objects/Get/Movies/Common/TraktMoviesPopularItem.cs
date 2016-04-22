namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    public class TraktMoviesPopularItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
