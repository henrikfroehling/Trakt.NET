namespace TraktApiSharp.Objects.Get.Recommendations
{
    using Newtonsoft.Json;

    public abstract class TraktRecommendation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }
    }
}
