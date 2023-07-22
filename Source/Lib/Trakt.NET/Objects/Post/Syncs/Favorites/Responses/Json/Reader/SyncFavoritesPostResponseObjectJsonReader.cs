namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncFavoritesPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncFavoritesPostResponse>
    {
        public override async Task<ITraktSyncFavoritesPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncFavoritesPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();
                var listDataReader = new PostResponseListDataObjectJsonReader();
                ITraktSyncFavoritesPostResponse syncFavoritesPostResponse = new TraktSyncFavoritesPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            syncFavoritesPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXISTING:
                            syncFavoritesPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            syncFavoritesPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            syncFavoritesPostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncFavoritesPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncFavoritesPostResponse));
        }
    }
}
