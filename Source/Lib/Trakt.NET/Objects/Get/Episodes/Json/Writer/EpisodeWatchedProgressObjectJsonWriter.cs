namespace TraktNet.Objects.Get.Episodes.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeWatchedProgressObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeWatchedProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeWatchedProgress obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken).ConfigureAwait(false);
            }

            if (obj.LastWatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_LAST_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LastWatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
