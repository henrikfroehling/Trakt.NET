namespace TraktApiSharp.Objects.Recommendations
{
    using Movies;
    using Newtonsoft.Json;

    public class TraktMovieRecommendation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
