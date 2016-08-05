namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Attributes;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeCheckinPostResponse : TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
