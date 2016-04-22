namespace TraktApiSharp.Objects.Get.Recommendations
{
    using Movies;
    using Newtonsoft.Json;

    public class TraktMovieRecommendation : TraktRecommendation
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
