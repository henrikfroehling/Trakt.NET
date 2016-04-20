namespace TraktApiSharp.Objects.Get.Recommendations
{
    using Newtonsoft.Json;
    using Shows;

    public class TraktShowRecommendation : TraktRecommendation
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }
    }
}
