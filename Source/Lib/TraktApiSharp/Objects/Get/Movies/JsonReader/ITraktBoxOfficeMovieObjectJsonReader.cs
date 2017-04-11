namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktBoxOfficeMovieObjectJsonReader : ITraktObjectJsonReader<ITraktBoxOfficeMovie>
    {
        private const string PROPERTY_NAME_REVENUE = "revenue";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktBoxOfficeMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktBoxOfficeMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktBoxOfficeMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktBoxOfficeMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktBoxOfficeMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktBoxOfficeMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktBoxOfficeMovie traktBoxOfficeMovie = new TraktBoxOfficeMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_REVENUE:
                            traktBoxOfficeMovie.Revenue = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktBoxOfficeMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktBoxOfficeMovie;
            }

            return await Task.FromResult(default(ITraktBoxOfficeMovie));
        }
    }
}
