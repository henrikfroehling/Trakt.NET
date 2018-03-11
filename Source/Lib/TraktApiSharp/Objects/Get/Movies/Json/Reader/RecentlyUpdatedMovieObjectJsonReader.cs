namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedMovieObjectJsonReader : AObjectJsonReader<ITraktRecentlyUpdatedMovie>
    {
        public override async Task<ITraktRecentlyUpdatedMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRecentlyUpdatedMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktRecentlyUpdatedMovie traktRecentlyUpdatedMovie = new TraktRecentlyUpdatedMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedMovie.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_MOVIE:
                            traktRecentlyUpdatedMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecentlyUpdatedMovie;
            }

            return await Task.FromResult(default(ITraktRecentlyUpdatedMovie));
        }
    }
}
