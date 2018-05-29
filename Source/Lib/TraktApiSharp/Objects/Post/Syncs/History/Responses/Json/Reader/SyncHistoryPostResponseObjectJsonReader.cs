namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostResponse>
    {
        public override async Task<ITraktSyncHistoryPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncHistoryPostResponse syncHistoryPostResponse = new TraktSyncHistoryPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_ADDED:
                            syncHistoryPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncHistoryPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostResponse));
        }
    }
}
