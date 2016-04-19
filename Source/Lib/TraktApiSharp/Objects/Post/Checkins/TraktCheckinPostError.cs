namespace TraktApiSharp.Objects.Checkins
{
    using Newtonsoft.Json;
    using System;

    public class TraktCheckinPostError
    {
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
