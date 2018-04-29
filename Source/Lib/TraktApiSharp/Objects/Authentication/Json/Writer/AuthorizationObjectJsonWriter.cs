namespace TraktApiSharp.Objects.Authentication.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AuthorizationObjectJsonWriter : AObjectJsonWriter<ITraktAuthorization>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktAuthorization obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

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

            await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_EXPIRES_IN, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.ExpiresInSeconds, cancellationToken).ConfigureAwait(false);

            if (obj.TokenType != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_TOKEN_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TokenType.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.AUTHORIZATION_PROPERTY_NAME_CREATED_AT, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.CreatedAtTimestamp, cancellationToken).ConfigureAwait(false);

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
