namespace TraktApiSharp.Services
{
    using Authentication;
    using Extensions;
    using System;
    using Utils;

    /// <summary>Provides helper methods for serializing and deserializing Trakt objects.</summary>
    public static class TraktSerializationService
    {
        /// <summary>Serializes an <see cref="TraktAuthorization" /> instance to a Json string.</summary>
        /// <param name="authorization">The authorization information, which should be serialized.</param>
        /// <returns>A Json string, containing all properties of the given authorization.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given authorization is null.</exception>
        public static string Serialize(TraktAuthorization authorization)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            var anonymousAuthorization = new
            {
                AccessToken = authorization.AccessToken,
                RefreshToken = authorization.RefreshToken,
                ExpiresIn = authorization.ExpiresIn,
                Scope = authorization.AccessScope.ObjectName,
                TokenType = authorization.TokenType.ObjectName,
                CreatedAt = authorization.Created.ToTraktLongDateTimeString(),
                IgnoreExpiration = authorization.IgnoreExpiration
            };

            return Json.Serialize(anonymousAuthorization);
        }

        public static TraktAuthorization Deserialize(string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
                throw new ArgumentException("authorization is invalid", nameof(authorization));

            return null;
        }
    }
}
