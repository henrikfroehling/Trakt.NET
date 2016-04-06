namespace TraktApiSharp.Objects
{
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using People;
    using Shows;
    using Shows.Episodes;
    using Users.Lists;

    public class TraktSearchResult
    {
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktSearchResultTypeConverter))]
        public TraktSearchResultType Type { get; set; }

        [JsonProperty(PropertyName = "score")]
        public decimal? Score { get; set; }

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
