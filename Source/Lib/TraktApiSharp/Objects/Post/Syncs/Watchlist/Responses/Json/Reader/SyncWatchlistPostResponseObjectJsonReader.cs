namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostResponse>
    {
        public override async Task<ITraktSyncWatchlistPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_ADDED:
                            syncWatchlistPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_EXISTING:
                            syncWatchlistPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
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
