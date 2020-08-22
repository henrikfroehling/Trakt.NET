namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncHistoryPostShowSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostShowSeason>
    {
        public override async Task<ITraktSyncHistoryPostShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryPostShowEpisode>();
                ITraktSyncHistoryPostShowSeason syncHistoryPostShowSeason = new TraktSyncHistoryPostShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_WATCHED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostShowSeason.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostShowSeason.Number = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncHistoryPostShowSeason.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostShowSeason;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostShowSeason));
        }
    }
}
