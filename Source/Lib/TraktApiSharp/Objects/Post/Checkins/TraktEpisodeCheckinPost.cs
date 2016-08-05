namespace TraktApiSharp.Objects.Post.Checkins
{
    using Attributes;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeCheckinPost : TraktCheckinPost
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
