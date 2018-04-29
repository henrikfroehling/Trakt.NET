namespace TraktApiSharp.Objects.Authentication
{
    using System;

    public interface ITraktDevice : IEquatable<ITraktDevice>
    {
        string DeviceCode { get; set; }

        string UserCode { get; set; }

        string VerificationUrl { get; set; }

        uint ExpiresInSeconds { get; set; }

        uint IntervalInSeconds { get; set; }

        uint IntervalInMilliseconds { get; }

        bool IsValid { get; }

        DateTime CreatedAt { get; }

        bool IsExpiredUnused { get; }

        string ToString();
    }
}
