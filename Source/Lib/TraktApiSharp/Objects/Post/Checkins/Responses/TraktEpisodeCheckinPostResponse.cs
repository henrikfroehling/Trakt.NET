namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeCheckinPostResponse : TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
