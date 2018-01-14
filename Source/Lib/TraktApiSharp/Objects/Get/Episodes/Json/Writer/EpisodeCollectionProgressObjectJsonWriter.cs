namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCollectionProgressObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeCollectionProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeCollectionProgress obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken);
            }

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COLLECTED_AT, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
