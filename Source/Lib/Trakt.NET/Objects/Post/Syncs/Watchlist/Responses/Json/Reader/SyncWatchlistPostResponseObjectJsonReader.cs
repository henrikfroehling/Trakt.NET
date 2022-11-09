namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Reader;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostResponse>
    {
        public override async Task<ITraktSyncWatchlistPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                var listDataReader = new PostResponseListDataObjectJsonReader();
                ITraktSyncWatchlistPostResponse syncWatchlistPostResponse = new TraktSyncWatchlistPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            syncWatchlistPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXISTING:
                            syncWatchlistPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            syncWatchlistPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            syncWatchlistPostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
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
