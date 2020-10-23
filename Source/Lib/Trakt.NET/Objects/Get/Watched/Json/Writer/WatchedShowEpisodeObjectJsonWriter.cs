namespace TraktNet.Objects.Get.Watched.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktWatchedShowEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktWatchedShowEpisode obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Plays.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PLAYS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Plays, cancellationToken).ConfigureAwait(false);
            }

            if (obj.LastWatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LAST_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LastWatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
