namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundMovieObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public override async Task<ITraktSyncRatingsPostResponseNotFoundMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsReader = new MovieIdsObjectJsonReader();
                ITraktSyncRatingsPostResponseNotFoundMovie syncRatingsPostResponseNotFoundMovie = new TraktSyncRatingsPostResponseNotFoundMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_RATING:
                            syncRatingsPostResponseNotFoundMovie.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_IDS:
                            syncRatingsPostResponseNotFoundMovie.Ids = await movieIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundMovie;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundMovie));
        }
    }
}
