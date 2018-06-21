namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public override async Task<ITraktSyncHistoryRemovePostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponseGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncHistoryRemovePostResponseGroup syncHistoryRemovePostResponseGroup = new TraktSyncHistoryRemovePostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES:
                            syncHistoryRemovePostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS:
                            syncHistoryRemovePostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS:
                            syncHistoryRemovePostResponseGroup.Seasons = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES:
                            syncHistoryRemovePostResponseGroup.Episodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_GROUP_PROPERTY_NAME_IDS:
                            syncHistoryRemovePostResponseGroup.HistoryIds = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostResponseGroup;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponseGroup));
        }
    }
}
