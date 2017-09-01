namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktRecentlyUpdatedMovieObjectJsonReader : IObjectJsonReader<ITraktRecentlyUpdatedMovie>
    {
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktRecentlyUpdatedMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktRecentlyUpdatedMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktRecentlyUpdatedMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktRecentlyUpdatedMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktRecentlyUpdatedMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedMovie.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_MOVIE:
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
