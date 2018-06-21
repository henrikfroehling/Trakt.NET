namespace TraktNet.Services
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Authentication;
    using System;
    using System.IO;
    using System.Text;

    /// <summary>Provides helper methods for serializing and deserializing Trakt objects.</summary>
    public static class TraktSerializationService
    {
        private const string propertyAccessToken = "AccessToken";
        private const string propertyRefreshToken = "RefreshToken";
        private const string propertyExpiresIn = "ExpiresIn";
        private const string propertyScope = "Scope";
        private const string propertyTokenType = "TokenType";
        private const string propertyCreatedAtTicks = "CreatedAtTicks";
        private const string propertyIgnoreExpiration = "IgnoreExpiration";

        /// <summary>Serializes an <see cref="TraktAuthorization" /> instance to a JSON string.</summary>
        /// <param name="authorization">The authorization information, which should be serialized.</param>
        /// <returns>A Json string, containing all properties of the given authorization.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given authorization is null.</exception>
        public static string Serialize(TraktAuthorization authorization)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            TraktAccessScope scope = authorization.Scope ?? TraktAccessScope.Public;
            TraktAccessTokenType tokenType = authorization.TokenType ?? TraktAccessTokenType.Bearer;
            string accessToken = authorization.AccessToken ?? string.Empty;
            string refreshToken = authorization.RefreshToken ?? string.Empty;

            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);

            using (var writer = new JsonTextWriter(stringWriter))
            {
                writer.Formatting = Formatting.None;

                writer.WriteStartObject();
                writer.WritePropertyName(propertyAccessToken);
                writer.WriteValue(accessToken);
                writer.WritePropertyName(propertyRefreshToken);
                writer.WriteValue(refreshToken);
                writer.WritePropertyName(propertyExpiresIn);
                writer.WriteValue(authorization.ExpiresInSeconds);
                writer.WritePropertyName(propertyScope);
                writer.WriteValue(scope.ObjectName);
                writer.WritePropertyName(propertyTokenType);
                writer.WriteValue(tokenType.ObjectName);
                writer.WritePropertyName(propertyCreatedAtTicks);
                writer.WriteValue(authorization.CreatedAt.Ticks);
                writer.WritePropertyName(propertyIgnoreExpiration);
                writer.WriteValue(authorization.IgnoreExpiration);
                writer.WriteEndObject();
            }

            return stringBuilder.ToString();
        }

        /// <summary>Deserializes a JSON string to an <see cref="TraktAuthorization" /> instance.</summary>
        /// <param name="authorizationJson">The JSON string, which should be deserialized.</param>
        /// <returns>
        /// An <see cref="TraktAuthorization" /> instance, containing the information from the JSON string, if successful.
        /// If the JSON string could not be parsed, null will be returned.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown, if the given authorizationJson is null, empty or invalid.</exception>
        public static TraktAuthorization DeserializeAuthorization(string authorizationJson)
        {
            if (string.IsNullOrEmpty(authorizationJson))
                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));

            var accessToken = string.Empty;
            var refreshToken = string.Empty;
            uint expiresIn = 0;
            var scope = string.Empty;
            var tokenType = string.Empty;
            long createdAtTicks = 0L;
            var ignoreExpiration = false;

            var stringReader = new StringReader(authorizationJson);

            try
            {
                using (var reader = new JsonTextReader(stringReader))
                {
                    if (reader.Read() && reader.TokenType != JsonToken.StartObject)
                        return default(TraktAuthorization);

                    while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = (string)reader.Value;

                        if (string.IsNullOrEmpty(propertyName))
                            throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));

                        if (propertyName == propertyAccessToken)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.String)
                                accessToken = (string)reader.Value;
                            else
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                        }
                        else if (propertyName == propertyRefreshToken)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.String)
                                refreshToken = (string)reader.Value;
                            else
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                        }
                        else if (propertyName == propertyExpiresIn)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.Integer)
                            {
                                var value = reader.Value.ToString();

                                if (!string.IsNullOrEmpty(value))
                                    expiresIn = uint.Parse(value);
                            }
                            else
                            {
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                            }
                        }
                        else if (propertyName == propertyScope)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.String)
                                scope = (string)reader.Value;
                            else
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                        }
                        else if (propertyName == propertyTokenType)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.String)
                                tokenType = (string)reader.Value;
                            else
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                        }
                        else if (propertyName == propertyCreatedAtTicks)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.Integer)
                            {
                                var value = reader.Value.ToString();

                                if (!string.IsNullOrEmpty(value))
                                    createdAtTicks = long.Parse(value);
                            }
                            else
                            {
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                            }
                        }
                        else if (propertyName == propertyIgnoreExpiration)
                        {
                            if (reader.Read() && reader.TokenType == JsonToken.Boolean)
                                ignoreExpiration = (bool)reader.Value;
                            else
                                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));
                        }
                        else
                        {
                            return default(TraktAuthorization);
                        }
                    }
                }
            }
            catch (JsonReaderException ex)
            {
                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson), ex);
            }

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(tokenType))
                return default(TraktAuthorization);

            TraktAccessScope accessScope = scope != string.Empty ? TraktEnumeration.FromObjectName<TraktAccessScope>(scope) : TraktAccessScope.Public;
            TraktAccessTokenType accessTokenType = tokenType != string.Empty ? TraktEnumeration.FromObjectName<TraktAccessTokenType>(tokenType) : TraktAccessTokenType.Bearer;
            var createdDateTime = new DateTime(createdAtTicks, DateTimeKind.Utc);

            return new TraktAuthorization
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresInSeconds = expiresIn,
                Scope = accessScope,
                TokenType = accessTokenType,
                IgnoreExpiration = ignoreExpiration//,
                //CreatedAt = createdDateTime
            };
        }
    }
}
