namespace TraktApiSharp.Objects.Basic
{
    using Enums;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Users.Lists;
    using Newtonsoft.Json;

    public class TraktSearchResult
    {
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktSearchResultTypeConverter))]
        public TraktSearchResultType Type { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float? Score { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }

        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }
    }
}
