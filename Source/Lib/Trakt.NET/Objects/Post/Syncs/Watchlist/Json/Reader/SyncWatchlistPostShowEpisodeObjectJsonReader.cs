namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncWatchlistPostShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostShowEpisode>
    {
        public override async Task<ITraktSyncWatchlistPostShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncWatchlistPostShowEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncWatchlistPostShowEpisode syncWatchlistPostShowEpisode = new TraktSyncWatchlistPostShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_WATCHLIST_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncWatchlistPostShowEpisode.Number = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostShowEpisode;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostShowEpisode));
        }
    }
}
