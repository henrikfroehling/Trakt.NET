namespace TraktNet.Objects.Post.Syncs.Collection.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowEpisodeObjectJsonWriter : AMetadataObjectJsonWriter<ITraktSyncCollectionPostShowEpisode>
    {
        protected override async Task WriteMetadataObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostShowEpisode obj, CancellationToken cancellationToken = default)
        {
            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await base.WriteMetadataObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
        }
    }
}
