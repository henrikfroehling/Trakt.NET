namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Attributes;
    using Basic;
    using Enums;
    using Newtonsoft.Json;

    public abstract class TraktScrobblePostResponse
    {
        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktScrobbleActionTypeConverter))]
        [Nullable]
        public TraktScrobbleActionType Action { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public float? Progress { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }
    }
}
