namespace TraktNet.Objects.Get.Collections.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktCollectionShowEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCollectionShowEpisode obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_EPISODE_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_EPISODE_PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Metadata != null)
            {
                var metadataObjectJsonWriter = new MetadataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_EPISODE_PROPERTY_NAME_METADATA, cancellationToken).ConfigureAwait(false);
                await metadataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Metadata, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
