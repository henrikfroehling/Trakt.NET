namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
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
        [JsonConverter(typeof(TraktEnumerationConverter<TraktObjectType>))]
        [Nullable]
        public TraktObjectType Type { get; set; }

        [JsonProperty(PropertyName = "comment")]
        [Nullable]
        public TraktComment Comment { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        [Nullable]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "list")]
        [Nullable]
        public TraktList List { get; set; }
    }
}
