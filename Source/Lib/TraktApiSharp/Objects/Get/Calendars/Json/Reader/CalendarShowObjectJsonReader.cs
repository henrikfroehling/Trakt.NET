namespace TraktApiSharp.Objects.Get.Calendars.Json.Reader
{
    using Episodes.Json;
    using Episodes.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json;
    using Shows.Json.Reader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarShowObjectJsonReader : IObjectJsonReader<ITraktCalendarShow>
    {
        public Task<ITraktCalendarShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCalendarShow));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCalendarShow> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCalendarShow));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCalendarShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCalendarShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktCalendarShow traktCalendarShow = new TraktCalendarShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCalendarShow.FirstAiredInCalendar = value.Second;

                                break;
                            }
                        case JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_SHOW:
                            traktCalendarShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_EPISODE:
                            traktCalendarShow.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCalendarShow;
            }

            return await Task.FromResult(default(ITraktCalendarShow));
        }
    }
}
