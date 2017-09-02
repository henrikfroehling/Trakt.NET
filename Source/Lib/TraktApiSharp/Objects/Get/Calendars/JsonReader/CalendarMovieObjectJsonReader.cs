namespace TraktApiSharp.Objects.Get.Calendars.JsonReader
{
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarMovieObjectJsonReader : IObjectJsonReader<ITraktCalendarMovie>
    {
        private const string PROPERTY_NAME_RELEASED = "released";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktCalendarMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCalendarMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCalendarMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCalendarMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCalendarMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCalendarMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RELEASED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCalendarMovie.CalendarRelease = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_MOVIE:
                            traktCalendarMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCalendarMovie;
            }

            return await Task.FromResult(default(ITraktCalendarMovie));
        }
    }
}
