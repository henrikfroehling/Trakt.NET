namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Writer
{
    using Basic.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AScrobblePostResponseObjectJsonWriter<TScrobbleResponseObjectType> : AObjectJsonWriter<TScrobbleResponseObjectType> where TScrobbleResponseObjectType : ITraktScrobblePostResponse
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TScrobbleResponseObjectType obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.SCROBBLE_POST_RESPONSE_PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.Action != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SCROBBLE_POST_RESPONSE_PROPERTY_NAME_ACTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Action.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Progress.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SCROBBLE_POST_RESPONSE_PROPERTY_NAME_PROGRESS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Progress, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SCROBBLE_POST_RESPONSE_PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }

            await WriteScrobbleResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected abstract Task WriteScrobbleResponseObjectAsync(JsonTextWriter jsonWriter, TScrobbleResponseObjectType obj, CancellationToken cancellationToken = default);
    }
}
