namespace TraktNet.Objects.Authentication
{
    using Enums;
    using System;

    public interface ITraktAuthorization : IEquatable<ITraktAuthorization>
    {
        string AccessToken { get; set; }

        string RefreshToken { get; set; }

        TraktAccessScope Scope { get; set; }

        uint ExpiresInSeconds { get; set; }

        TraktAccessTokenType TokenType { get; set; }

        ulong CreatedAtTimestamp { get; set; }

        bool IsExpired { get; }

        bool IsValid { get; }

        bool IsRefreshPossible { get; }

        DateTime CreatedAt { get; }

        bool IgnoreExpiration { get; set; }

        string ToString();
    }
}
