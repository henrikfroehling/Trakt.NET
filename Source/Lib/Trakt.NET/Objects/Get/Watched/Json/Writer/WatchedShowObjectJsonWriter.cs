namespace TraktNet.Objects.Get.Watched.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowObjectJsonWriter : AObjectJsonWriter<ITraktWatchedShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktWatchedShow obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

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

            if (obj.LastUpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LAST_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LastUpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.ResetAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RESET_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ResetAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.WatchedSeasons != null)
            {
                var watchedShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktWatchedShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await watchedShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.WatchedSeasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
