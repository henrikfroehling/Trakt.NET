namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeScrobblePost : TraktScrobblePost
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }
    }
}
