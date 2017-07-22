namespace TraktApiSharp.Objects.Post.Checkins.Responses.Implementations
{
    using System;

    /// <summary>Represents a checkin error response.</summary>
    public class TraktCheckinPostErrorResponse : ITraktCheckinPostErrorResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the current checkin expires.</summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
