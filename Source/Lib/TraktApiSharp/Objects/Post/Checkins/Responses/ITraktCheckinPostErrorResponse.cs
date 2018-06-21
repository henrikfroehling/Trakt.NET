namespace TraktNet.Objects.Post.Checkins.Responses
{
    using System;

    public interface ITraktCheckinPostErrorResponse
    {
        DateTime? ExpiresAt { get; set; }
    }
}
