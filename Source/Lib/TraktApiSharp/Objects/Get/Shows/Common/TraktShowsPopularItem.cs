namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Basic;
    using Newtonsoft.Json;

    public class TraktShowsPopularItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktIds Ids { get; set; }
    }
}
