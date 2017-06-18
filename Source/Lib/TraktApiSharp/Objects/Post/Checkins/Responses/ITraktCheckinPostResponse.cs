namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Basic;
    using System;

    public interface ITraktCheckinPostResponse
    {
        ulong Id { get; set; }

        DateTime? WatchedAt { get; set; }

        ITraktSharing Sharing { get; set; }
    }
}
