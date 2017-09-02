namespace TraktApiSharp.Objects.Get.Calendars.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarMovieArrayJsonReader : IArrayJsonReader<ITraktCalendarMovie>
    {
        public Task<IEnumerable<ITraktCalendarMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCalendarMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCalendarMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCalendarMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCalendarMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
