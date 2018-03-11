namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistPostShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistPostShowSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);

            if (obj.Episodes != null)
            {
                var syncWatchlistPostShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
