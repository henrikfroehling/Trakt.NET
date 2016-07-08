namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Basic;
    using Enums;
    using Newtonsoft.Json;

    public abstract class TraktScrobblePostResponse
    {
        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktScrobbleActionTypeConverter))]
        public TraktScrobbleActionType? Action { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public float? Progress { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }
    }
}
