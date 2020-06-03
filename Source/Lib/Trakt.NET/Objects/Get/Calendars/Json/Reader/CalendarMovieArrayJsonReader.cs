namespace TraktNet.Objects.Get.Calendars.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarMovieArrayJsonReader : AArrayJsonReader<ITraktCalendarMovie>
    {
        public override async Task<IEnumerable<ITraktCalendarMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCalendarMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var calendarMovieReader = new CalendarMovieObjectJsonReader();
                var calendarMovies = new List<ITraktCalendarMovie>();
                ITraktCalendarMovie calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (calendarMovie != null)
                {
                    calendarMovies.Add(calendarMovie);
                    calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return calendarMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCalendarMovie>));
        }
    }
}
