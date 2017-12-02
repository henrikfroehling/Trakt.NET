namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowObjectJsonReader : IObjectJsonReader<ITraktMostPWCShow>
    {
        public Task<ITraktMostPWCShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMostPWCShow));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMostPWCShow> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMostPWCShow));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMostPWCShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMostPWCShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                ITraktMostPWCShow traktMostPWCShow = new TraktMostPWCShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.MOST_PWC_SHOW_PROPERTY_NAME_WATCHER_COUNT:
                            traktMostPWCShow.WatcherCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.MOST_PWC_SHOW_PROPERTY_NAME_PLAY_COUNT:
                            traktMostPWCShow.PlayCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.MOST_PWC_SHOW_PROPERTY_NAME_COLLECTED_COUNT:
                            traktMostPWCShow.CollectedCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.MOST_PWC_SHOW_PROPERTY_NAME_COLLECTOR_COUNT:
                            traktMostPWCShow.CollectorCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.MOST_PWC_SHOW_PROPERTY_NAME_SHOW:
                            traktMostPWCShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMostPWCShow;
            }

            return await Task.FromResult(default(ITraktMostPWCShow));
        }
    }
}
