namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistRemovePostResponse>
    {
        public override async Task<ITraktSyncWatchlistRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncWatchlistRemovePostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncWatchlistRemovePostResponse syncWatchlistRemovePostResponse = new TraktSyncWatchlistRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_WATCHLIST_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED:
                            syncWatchlistRemovePostResponse.Deleted = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_WATCHLIST_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncWatchlistRemovePostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistRemovePostResponse;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistRemovePostResponse));
        }
    }
}
