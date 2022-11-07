namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;
    using TraktNet.Utils;

    internal class SyncHistoryRemovePostShowSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostShowSeason>
    {
        public override async Task<ITraktSyncHistoryRemovePostShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryRemovePostShowEpisode>();
                ITraktSyncHistoryRemovePostShowSeason syncHistoryRemovePostShowSeason = new TraktSyncHistoryRemovePostShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryRemovePostShowSeason.Number = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncHistoryRemovePostShowSeason.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostShowSeason;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostShowSeason));
        }
    }
}
