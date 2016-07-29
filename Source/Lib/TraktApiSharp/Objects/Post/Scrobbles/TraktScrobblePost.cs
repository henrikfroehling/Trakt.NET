namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Newtonsoft.Json;

    public abstract class TraktScrobblePost
    {
        [JsonProperty(PropertyName = "progress")]
        public float Progress { get; set; }

        [JsonProperty(PropertyName = "app_version")]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "app_date")]
        public string AppDate { get; set; }
    }
}
