namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostEpisode>
    {
        public override async Task<ITraktSyncWatchlistPostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsObjectJsonReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncWatchlistPostEpisode syncWatchlistPostEpisode = new TraktSyncWatchlistPostEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncWatchlistPostEpisode.Ids = await episodeIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostEpisode;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostEpisode));
        }
    }
}
