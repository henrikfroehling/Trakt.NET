namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Newtonsoft.Json;
    using System;

    /// <summary>Represents a checkin error response.</summary>
    public class TraktCheckinPostErrorResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the current checkin expires.</summary>
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime? ExpiresAt { get; set; }
    }
}
