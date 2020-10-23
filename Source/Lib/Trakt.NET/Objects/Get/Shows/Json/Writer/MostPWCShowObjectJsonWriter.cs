namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowObjectJsonWriter : AObjectJsonWriter<ITraktMostPWCShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMostPWCShow obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.WatcherCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHER_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatcherCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.PlayCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PLAY_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.PlayCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectedCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTED_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectorCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTOR_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectorCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
