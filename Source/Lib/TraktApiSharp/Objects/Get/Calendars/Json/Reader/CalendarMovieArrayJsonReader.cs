namespace TraktApiSharp.Objects.Get.Calendars.Json.Reader
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
                //var calendarMovieReadingTasks = new List<Task<ITraktCalendarMovie>>();
                var calendarMovies = new List<ITraktCalendarMovie>();

                //calendarMovieReadingTasks.Add(calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCalendarMovie calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (calendarMovie != null)
                {
                    calendarMovies.Add(calendarMovie);
                    //calendarMovieReadingTasks.Add(calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCalendarMovies = await Task.WhenAll(calendarMovieReadingTasks);
                //return (IEnumerable<ITraktCalendarMovie>)readCalendarMovies.GetEnumerator();
                return calendarMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCalendarMovie>));
        }
    }
}
