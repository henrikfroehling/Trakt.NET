namespace TraktNet.Objects.Post.Shows
{
    using Requests.Interfaces;
    using System;

    /// <summary>
    /// A Trakt post for resetting the watched progress of a show, containing an optional reset_at UTC date to have it
    /// calculate progress from that specific date onwards.
    /// </summary>
    public interface ITraktShowResetWatchedProgressPost : IRequestBody
    {
        /// <summary>An optional reset_at UTC date to have it calculate progress from that specific date onwards.</summary>
        DateTime? ResetAt { get; set; }
    }
}
