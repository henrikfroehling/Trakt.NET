namespace TraktNet.Objects.Post.Syncs.Collection.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Get.Episodes.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktSyncCollectionPostEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostEpisode obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var episodeIdsObjectJsonWriter = new EpisodeIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await episodeIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Metadata != null)
            {
                var metadataObjectJsonWriter = new MetadataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_METADATA, cancellationToken).ConfigureAwait(false);
                await metadataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Metadata, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
