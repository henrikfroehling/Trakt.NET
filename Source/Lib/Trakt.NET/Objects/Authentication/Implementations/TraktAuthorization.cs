namespace TraktNet.Objects.Authentication
{
    using Enums;
    using Extensions;
    using System;

    /// <summary>
    /// Represents a Trakt authorization response, which contains information, such as access token and refresh token.
    /// </summary>
    public class TraktAuthorization : ITraktAuthorization
    {
        private const uint DEFAULT_EXPIRES_IN_SECONDS = 7776000;

        /// <summary>Gets or sets the access token.</summary>
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token. Use this to exchange it for a new access token.</summary>
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the token scope. See also <seealso cref="TraktAccessScope" />.</summary>
        public TraktAccessScope Scope { get; set; }

        /// <summary>Gets or sets the seconds, after which this authorization will expire.</summary>
        public uint ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        public TraktAccessTokenType TokenType { get; set; }

        /// <summary>Gets or sets the timestamp, when this token was created.</summary>
        public ulong CreatedAtTimestamp { get; set; }

        /// <summary>
        /// Returns, whether this authorization information is expired.
        /// <para>
        /// Returns false, if <see cref="IsValid" /> returns false, or, if the authorization information is expired.
        /// </para>
        /// </summary>
        public bool IsExpired => !IsValid || (!IgnoreExpiration && CreatedAt.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow);

        /// <summary>
        /// Returns, whether this authorization information is valid.
        /// <para>
        /// Returns false, if <see cref="AccessToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(AccessToken) && !AccessToken.ContainsSpace();

        /// <summary>
        /// Returns, whether this authorization information can be refreshed with a refresh token.
        /// <para>
        /// Returns false, if <see cref="RefreshToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        public bool IsRefreshPossible => !string.IsNullOrEmpty(RefreshToken) && !RefreshToken.ContainsSpace();

        /// <summary>Returns the UTC DateTime, when this authorization information was created.</summary>
        public DateTime CreatedAt => CreatedAtTimestamp > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(CreatedAtTimestamp) : default;

        /// <summary>Gets or sets, whether token expiration should be ignored.</summary>
        public bool IgnoreExpiration { get; set; }

        /// <summary>Gets a string representation of the authorization token.</summary>
        /// <returns>A string representation of the authorization token.</returns>
        public override string ToString()
        {
            string value = IsValid ? AccessToken : "no valid access token";
            value += IsExpired ? " (expired)" : $" (valid until {CreatedAt.AddSeconds(ExpiresInSeconds)})";
            return value;
        }

        /// <summary>Compares this instance with another <see cref="ITraktAuthorization" /> instance.</summary>
        /// <param name="other">The other <see cref="ITraktAuthorization" /> instance, with which this instance will be compared.</param>
        /// <returns>True, if both instances are equal, otherwise false.</returns>
        public bool Equals(ITraktAuthorization other)
            => other != null
                && other.IsValid == IsValid
                && other.IsExpired == IsExpired
                && other.IsRefreshPossible == IsRefreshPossible
                && other.ExpiresInSeconds == ExpiresInSeconds
                && other.CreatedAtTimestamp == CreatedAtTimestamp
                && other.CreatedAt == CreatedAt
                && other.AccessToken == AccessToken
                && other.RefreshToken == RefreshToken
                && other.Scope == Scope
                && other.TokenType == TokenType;

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(string accessToken, string refreshToken = null)
        {
            TraktAuthorization traktAuthorization = CreateWith(DateTime.UtcNow, accessToken, refreshToken);
            traktAuthorization.IgnoreExpiration = true;
            return traktAuthorization;
        }

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(uint expiresInSeconds, string accessToken, string refreshToken = null)
            => CreateWith(DateTime.UtcNow, expiresInSeconds, accessToken, refreshToken);

        /// <summary>
        /// Creates a new <see cref="TraktAuthorization" /> instance with the given values.
        /// <see cref="ExpiresInSeconds" /> of the created <see cref="TraktAuthorization" /> instance will have the default
        /// value of 3600 * 24 * 90 seconds, equal to 90 days.
        /// </summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(DateTime createdAt, string accessToken, string refreshToken = null)
        {
            TraktAuthorization traktAuthorization = CreateWith(createdAt, DEFAULT_EXPIRES_IN_SECONDS, accessToken, refreshToken);
            traktAuthorization.IgnoreExpiration = true;
            return traktAuthorization;
        }

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(DateTime createdAt, uint expiresInSeconds,
                                                    string accessToken, string refreshToken = null)
            => new TraktAuthorization
            {
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty,
                Scope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = expiresInSeconds,
                CreatedAtTimestamp = CalculateTimestamp(createdAt)
            };

        private static ulong CalculateTimestamp(DateTime createdAt)
        {
            const long ticksPerMilliseconds = TimeSpan.TicksPerMillisecond;
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long originMilliseconds = origin.Ticks / ticksPerMilliseconds;
            DateTime utcCreatedAt = createdAt.ToUniversalTime();
            long utcCreatedAtMilliseconds = utcCreatedAt.Ticks / ticksPerMilliseconds;
            long differenceInMilliseconds = utcCreatedAtMilliseconds - originMilliseconds;
            return (ulong)(differenceInMilliseconds / 1000);
        }
    }
}
