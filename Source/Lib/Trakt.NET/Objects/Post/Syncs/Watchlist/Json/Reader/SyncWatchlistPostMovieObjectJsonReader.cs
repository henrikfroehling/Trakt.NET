namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostMovieObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostMovie>
    {
        public override async Task<ITraktSyncWatchlistPostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncWatchlistPostMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsObjectJsonReader = new MovieIdsObjectJsonReader();
                ITraktSyncWatchlistPostMovie syncWatchlistPostMovie = new TraktSyncWatchlistPostMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TITLE:
                            syncWatchlistPostMovie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_YEAR:
                            syncWatchlistPostMovie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncWatchlistPostMovie.Ids = await movieIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostMovie;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostMovie));
        }
    }
}
