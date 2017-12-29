namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionRemovePostResponse>
    {
        public override async Task<ITraktSyncCollectionRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncCollectionRemovePostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncCollectionRemovePostResponse syncCollectionPostResponse = new TraktSyncCollectionRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_COLLECTION_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED:
                            syncCollectionPostResponse.Deleted = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncCollectionPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncCollectionPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncCollectionRemovePostResponse));
        }
    }
}
