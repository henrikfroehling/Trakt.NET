namespace TraktNet.Objects.Get.Episodes.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCollectionProgressObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeCollectionProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeCollectionProgress obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
