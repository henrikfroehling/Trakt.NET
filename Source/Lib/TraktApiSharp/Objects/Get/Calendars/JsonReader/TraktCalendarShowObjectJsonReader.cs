namespace TraktApiSharp.Objects.Get.Calendars.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCalendarShowObjectJsonReader : ITraktObjectJsonReader<ITraktCalendarShow>
    {
        private const string PROPERTY_NAME_FIRST_AIRED = "first_aired";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_EPISODE = "episode";

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
                var showObjectReader = new TraktShowObjectJsonReader();
                var episodeObjectReader = new TraktEpisodeObjectJsonReader();

                ITraktCalendarShow traktCalendarShow = new TraktCalendarShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCalendarShow.FirstAiredInCalendar = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHOW:
                            traktCalendarShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
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
