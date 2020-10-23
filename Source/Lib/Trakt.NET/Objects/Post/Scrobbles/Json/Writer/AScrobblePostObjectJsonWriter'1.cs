namespace TraktNet.Objects.Post.Scrobbles.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AScrobblePostObjectJsonWriter<TScrobbleObjectType> : AObjectJsonWriter<TScrobbleObjectType> where TScrobbleObjectType : ITraktScrobblePost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TScrobbleObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PROGRESS, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Progress, cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.AppVersion))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_APP_VERSION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppVersion, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.AppDate))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_APP_DATE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppDate, cancellationToken).ConfigureAwait(false);
            }

            await WriteScrobbleObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected abstract Task WriteScrobbleObjectAsync(JsonTextWriter jsonWriter, TScrobbleObjectType obj, CancellationToken cancellationToken = default);
    }
}
