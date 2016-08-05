namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Attributes;
    using Newtonsoft.Json;

    public abstract class TraktScrobblePost
    {
        [JsonProperty(PropertyName = "progress")]
        public float Progress { get; set; }

        [JsonProperty(PropertyName = "app_version")]
        [Nullable]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "app_date")]
        [Nullable]
        public string AppDate { get; set; }
    }
}
