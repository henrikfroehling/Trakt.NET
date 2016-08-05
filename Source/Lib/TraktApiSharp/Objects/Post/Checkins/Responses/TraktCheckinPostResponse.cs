namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;
    using System;

    public abstract class TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }
    }
}
