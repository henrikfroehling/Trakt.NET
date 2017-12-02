namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseObjectJsonReader : IObjectJsonReader<ITraktSyncHistoryRemovePostResponse>
    {
        public Task<ITraktSyncHistoryRemovePostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncHistoryRemovePostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncHistoryRemovePostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncHistoryRemovePostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncHistoryRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncHistoryRemovePostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncHistoryRemovePostResponse syncHistoryRemovePostResponse = new TraktSyncHistoryRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED:
                            syncHistoryRemovePostResponse.Deleted = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncHistoryRemovePostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostResponse;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponse));
        }
    }
}
