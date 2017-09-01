namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader
{
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktPersonMovieCreditsCrewItemObjectJsonReader : IObjectJsonReader<ITraktPersonMovieCreditsCrewItem>
    {
        private const string PROPERTY_NAME_JOB = "job";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktPersonMovieCreditsCrewItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPersonMovieCreditsCrewItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPersonMovieCreditsCrewItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPersonMovieCreditsCrewItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPersonMovieCreditsCrewItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonMovieCreditsCrewItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();

                ITraktPersonMovieCreditsCrewItem movieCreditsCrewItem = new TraktPersonMovieCreditsCrewItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_JOB:
                            movieCreditsCrewItem.Job = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            movieCreditsCrewItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCreditsCrewItem;
            }

            return await Task.FromResult(default(ITraktPersonMovieCreditsCrewItem));
        }
    }
}
