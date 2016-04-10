namespace TraktApiSharp.Authentication
{
    using Newtonsoft.Json;
    using System;

    public class TraktDevice
    {
        public TraktDevice()
        {
            Created = DateTime.UtcNow;
        }

        [JsonProperty(PropertyName = "device_code")]
        public string DeviceCode { get; set; }

        [JsonProperty(PropertyName = "user_code")]
        public string UserCode { get; set; }

        [JsonProperty(PropertyName = "verification_url")]
        public string VerificationUrl { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresInSeconds { get; set; }

        [JsonProperty(PropertyName = "interval")]
        public int Interval { get; set; }

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(DeviceCode) && !IsExpiredUnused;

        [JsonIgnore]
        public DateTime Created { get; private set; }

        [JsonIgnore]
        public bool IsExpiredUnused => Created.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow;
    }
}
