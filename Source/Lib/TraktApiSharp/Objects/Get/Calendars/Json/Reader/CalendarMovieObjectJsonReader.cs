namespace TraktApiSharp.Objects.Get.Calendars.Json.Reader
{
    using Implementations;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarMovieObjectJsonReader : AObjectJsonReader<ITraktCalendarMovie>
    {
        public override async Task<ITraktCalendarMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.CALENDAR_MOVIE_PROPERTY_NAME_RELEASED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCalendarMovie.CalendarRelease = value.Second;

                                break;
                            }
                        case JsonProperties.CALENDAR_MOVIE_PROPERTY_NAME_MOVIE:
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
