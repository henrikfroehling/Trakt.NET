namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncFavoritesPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncFavoritesPostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncFavoritesPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var postResponseMoviesReader = new ArrayJsonReader<ITraktSyncFavoritesPostMovie>();
                var postResponseShowsReader = new ArrayJsonReader<ITraktSyncFavoritesPostShow>();
                ITraktSyncFavoritesPostResponseNotFoundGroup traktSyncFavoritesPostResponseNotFoundGroup = new TraktSyncFavoritesPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            traktSyncFavoritesPostResponseNotFoundGroup.Movies = await postResponseMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            traktSyncFavoritesPostResponseNotFoundGroup.Shows = await postResponseShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncFavoritesPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktSyncFavoritesPostResponseNotFoundGroup));
        }
    }
}
