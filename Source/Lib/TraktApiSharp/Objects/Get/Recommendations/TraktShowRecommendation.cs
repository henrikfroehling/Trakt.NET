namespace TraktApiSharp.Objects.Get.Recommendations
{
    using Newtonsoft.Json;
    using Shows;

    public class TraktShowRecommendation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }
    }
}
