namespace TraktApiSharp.Objects.Get.Calendars.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarShowArrayJsonReader : AArrayJsonReader<ITraktCalendarShow>
    {
        public override async Task<IEnumerable<ITraktCalendarShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
