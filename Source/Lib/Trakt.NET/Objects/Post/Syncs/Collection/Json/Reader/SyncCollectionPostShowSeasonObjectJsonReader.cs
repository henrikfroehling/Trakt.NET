namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostShowSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostShowSeason>
    {
        public override async Task<ITraktSyncCollectionPostShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncCollectionPostShowSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostShowSeason traktSyncCollectionPostShowSeason = new TraktSyncCollectionPostShowSeason();
                var syncCollectionPostShowEpisodeArrayJsonReader = new SyncCollectionPostShowEpisodeArrayJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostShowSeason.Number = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES:
                            traktSyncCollectionPostShowSeason.Episodes = await syncCollectionPostShowEpisodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostShowSeason;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostShowSeason));
        }
    }
}
