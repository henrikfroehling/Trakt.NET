namespace TraktNet.Objects.Get.Calendars.Json.Reader
{
    using Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarShowObjectJsonReader : AObjectJsonReader<ITraktCalendarShow>
    {
        public override async Task<ITraktCalendarShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
