namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncHistoryPostEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostEpisode>
    {
        public override async Task<ITraktSyncHistoryPostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryPostEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncHistoryPostEpisode syncHistoryPostEpisode = new TraktSyncHistoryPostEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_WATCHED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostEpisode.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryPostEpisode.Ids = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostEpisode;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostEpisode));
        }
    }
}
