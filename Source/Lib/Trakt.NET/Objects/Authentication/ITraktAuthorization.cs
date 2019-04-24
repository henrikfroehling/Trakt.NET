namespace TraktNet.Objects.Authentication
{
    using Enums;
    using System;

    /// <summary>
    /// Represents a Trakt authorization response, which contains information, such as access token and refresh token.
    /// </summary>
    public interface ITraktAuthorization : IEquatable<ITraktAuthorization>
    {
        /// <summary>Gets or sets the access token.</summary>
        string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token. Use this to exchange it for a new access token.</summary>
        string RefreshToken { get; set; }

        /// <summary>Gets or sets the token scope. See also <seealso cref="TraktAccessScope" />.</summary>
        TraktAccessScope Scope { get; set; }

        /// <summary>Gets or sets the seconds, after which this authorization will expire.</summary>
        uint ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        TraktAccessTokenType TokenType { get; set; }

        /// <summary>Gets or sets the timestamp, when this token was created.</summary>
        ulong CreatedAtTimestamp { get; set; }

        /// <summary>
        /// Returns, whether this authorization information is expired.
        /// <para>
        /// Returns false, if <see cref="IsValid" /> returns false, or, if the authorization information is expired.
        /// </para>
        /// </summary>
        bool IsExpired { get; }

        /// <summary>
        /// Returns, whether this authorization information is valid.
        /// <para>
        /// Returns false, if <see cref="AccessToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Returns, whether this authorization information can be refreshed with a refresh token.
        /// <para>
        /// Returns false, if <see cref="RefreshToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        bool IsRefreshPossible { get; }

        /// <summary>Returns the UTC DateTime, when this authorization information was created.</summary>
        DateTime CreatedAt { get; }

        /// <summary>Gets or sets, whether token expiration should be ignored.</summary>
        bool IgnoreExpiration { get; set; }

        /// <summary>Gets a string representation of the authorization token.</summary>
        /// <returns>A string representation of the authorization token.</returns>
        string ToString();
    }
}
