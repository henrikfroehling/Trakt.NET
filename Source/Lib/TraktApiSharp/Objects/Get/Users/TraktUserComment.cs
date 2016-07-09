namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Enums;
    using Lists;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;

    public class TraktUserComment
    {
        [JsonProperty(PropertyName = "type")]
        public TraktObjectType? Type { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public TraktComment Comment { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }
    }
}
