namespace TraktApiSharp.Objects.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktShowsPopularItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktIds Ids { get; set; }
    }
}
