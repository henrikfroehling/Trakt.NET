namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncHistoryPostSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostSeason>
    {
        public override async Task<ITraktSyncHistoryPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsReader = new SeasonIdsObjectJsonReader();
                ITraktSyncHistoryPostSeason syncHistoryPostSeason = new TraktSyncHistoryPostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_WATCHED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostSeason.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryPostSeason.Ids = await seasonIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostSeason;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostSeason));
        }
    }
}
