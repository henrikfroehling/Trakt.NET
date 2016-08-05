namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Attributes;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeScrobblePost : TraktScrobblePost
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
