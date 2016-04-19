namespace TraktApiSharp.Objects.Checkins
{
    using Newtonsoft.Json;
    using System;

    public class TraktCheckinError
    {
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
