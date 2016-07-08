namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Basic;
    using Newtonsoft.Json;
    using System;

    public abstract class TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }
    }
}
