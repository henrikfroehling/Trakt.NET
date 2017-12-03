namespace TraktApiSharp.Objects.Get.Calendars.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarShowArrayJsonReader : IArrayJsonReader<ITraktCalendarShow>
    {
        public Task<IEnumerable<ITraktCalendarShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCalendarShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCalendarShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCalendarShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCalendarShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCalendarShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var calendarShowReader = new CalendarShowObjectJsonReader();
                //var calendarShowReadingTasks = new List<Task<ITraktCalendarShow>>();
                var calendarShows = new List<ITraktCalendarShow>();

                //calendarShowReadingTasks.Add(calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCalendarShow calendarShow = await calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (calendarShow != null)
                {
                    calendarShows.Add(calendarShow);
                    //calendarShowReadingTasks.Add(calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    calendarShow = await calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCalendarShows = await Task.WhenAll(calendarShowReadingTasks);
                //return (IEnumerable<ITraktCalendarShow>)readCalendarShows.GetEnumerator();
                return calendarShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCalendarShow>));
        }
    }
}
