namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Syncs.Responses.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktSyncWatchlistPostResponseObjectJsonReader : IObjectJsonReader<ITraktSyncWatchlistPostResponse>
    {
        private const string PROPERTY_NAME_ADDED = "added";
        private const string PROPERTY_NAME_EXISTING = "existing";
        private const string PROPERTY_NAME_NOT_FOUND = "not_found";

        public Task<ITraktSyncWatchlistPostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncWatchlistPostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncWatchlistPostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncWatchlistPostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncWatchlistPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncWatchlistPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncWatchlistPostResponse syncWatchlistPostResponse = new TraktSyncWatchlistPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ADDED:
                            syncWatchlistPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EXISTING:
                            syncWatchlistPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_NOT_FOUND:
                            syncWatchlistPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostResponse));
        }
    }
}
