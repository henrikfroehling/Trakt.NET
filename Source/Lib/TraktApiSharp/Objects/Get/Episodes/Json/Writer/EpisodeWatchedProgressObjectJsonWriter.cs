namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeWatchedProgressObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeWatchedProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeWatchedProgress obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken);
            }

            if (obj.LastWatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_LAST_WATCHED_AT, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.LastWatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
