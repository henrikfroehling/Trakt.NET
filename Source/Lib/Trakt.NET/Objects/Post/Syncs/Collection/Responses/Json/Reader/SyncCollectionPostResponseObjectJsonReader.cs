namespace TraktNet.Objects.Post.Syncs.Collection.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostResponse>
    {
        public override async Task<ITraktSyncCollectionPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncCollectionPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncCollectionPostResponse syncCollectionPostResponse = new TraktSyncCollectionPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_ADDED:
                            syncCollectionPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_UPDATED:
                            syncCollectionPostResponse.Updated = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_EXISTING:
                            syncCollectionPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncCollectionPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncCollectionPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostResponse));
        }
    }
}
