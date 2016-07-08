namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Newtonsoft.Json;
    using System;

    public class TraktCheckinPostErrorResponse
    {
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime? ExpiresAt { get; set; }
    }
}
