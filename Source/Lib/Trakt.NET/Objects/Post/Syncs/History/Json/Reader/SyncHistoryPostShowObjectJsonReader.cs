namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncHistoryPostShowObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostShow>
    {
        public override async Task<ITraktSyncHistoryPostShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryPostShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsObjectJsonReader = new ShowIdsObjectJsonReader();
                var seasonArrayJsonReader = new SyncHistoryPostShowSeasonArrayJsonReader();
                ITraktSyncHistoryPostShow syncHistoryPostShow = new TraktSyncHistoryPostShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_WATCHED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostShow.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_TITLE:
                            syncHistoryPostShow.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_YEAR:
                            syncHistoryPostShow.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_IDS:
                            syncHistoryPostShow.Ids = await showIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_SEASONS:
                            syncHistoryPostShow.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostShow;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostShow));
        }
    }
}
