namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Attributes;
    using Newtonsoft.Json;

    public abstract class TraktScrobblePost
    {
        /// <summary>Gets or sets the required progress. Should be a value between 0 and 100.</summary>
        [JsonProperty(PropertyName = "progress")]
        public float Progress { get; set; }

        /// <summary>Gets or sets the app version for the scrobble post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "app_version")]
        [Nullable]
        public string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the scrobble post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "app_date")]
        [Nullable]
        public string AppDate { get; set; }
    }
}
