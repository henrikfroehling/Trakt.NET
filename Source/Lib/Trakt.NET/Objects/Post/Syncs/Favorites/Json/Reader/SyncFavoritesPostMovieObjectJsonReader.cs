namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncFavoritesPostMovieObjectJsonReader : AObjectJsonReader<ITraktSyncFavoritesPostMovie>
    {
        public override async Task<ITraktSyncFavoritesPostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncFavoritesPostMovie traktSyncFavoritesPostMovie = new TraktSyncFavoritesPostMovie();
                var movieIdsObjectJsonReader = new MovieIdsObjectJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TITLE:
                            traktSyncFavoritesPostMovie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_YEAR:
                            traktSyncFavoritesPostMovie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktSyncFavoritesPostMovie.Ids = await movieIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktSyncFavoritesPostMovie.Notes = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncFavoritesPostMovie;
            }

            return await Task.FromResult(default(ITraktSyncFavoritesPostMovie));
        }
    }
}
