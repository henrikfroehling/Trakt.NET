namespace TraktNet.Objects.Post.Checkins.Responses
{
    using System;

    /// <summary>Represents a checkin error response.</summary>
    public interface ITraktCheckinPostErrorResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the current checkin expires.</summary>
        DateTime? ExpiresAt { get; set; }
    }
}
