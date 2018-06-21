namespace TraktNet.Objects.Post.Syncs.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktSyncPostResponseGroup>
    {
        public override async Task<ITraktSyncPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncPostResponseGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncPostResponseGroup syncPostResponseGroup = new TraktSyncPostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES:
                            syncPostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS:
                            syncPostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS:
                            syncPostResponseGroup.Seasons = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES:
                            syncPostResponseGroup.Episodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncPostResponseGroup;
            }

            return await Task.FromResult(default(ITraktSyncPostResponseGroup));
        }
    }
}
