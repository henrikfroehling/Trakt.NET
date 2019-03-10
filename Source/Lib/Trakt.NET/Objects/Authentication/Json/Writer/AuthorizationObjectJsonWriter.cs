﻿namespace TraktNet.Objects.Authentication.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AuthorizationObjectJsonWriter : AObjectJsonWriter<ITraktAuthorization>
    {
        internal bool CompleteSerialization { get; set; }

        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktAuthorization obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.AccessToken))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_ACCESS_TOKEN, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AccessToken, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.RefreshToken))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_REFRESH_TOKEN, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RefreshToken, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Scope != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_SCOPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Scope.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ExpiresInSeconds > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_EXPIRES_IN, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ExpiresInSeconds, cancellationToken).ConfigureAwait(false);
            }

            if (obj.TokenType != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_TOKEN_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TokenType.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CreatedAtTimestamp > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_CREATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CreatedAtTimestamp, cancellationToken).ConfigureAwait(false);
            }

            if (CompleteSerialization)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_IGNORE_EXPIRATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.IgnoreExpiration, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
