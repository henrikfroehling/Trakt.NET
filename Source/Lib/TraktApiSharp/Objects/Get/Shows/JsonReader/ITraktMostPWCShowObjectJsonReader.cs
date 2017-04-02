namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktMostPWCShowObjectJsonReader : ITraktObjectJsonReader<ITraktMostPWCShow>
    {
        private const string PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        private const string PROPERTY_NAME_PLAY_COUNT = "play_count";
        private const string PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        private const string PROPERTY_NAME_COLLECTOR_COUNT = "collector_count";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktMostPWCShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMostPWCShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktMostPWCShow traktMostPWCShow = new TraktMostPWCShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHER_COUNT:
                            traktMostPWCShow.WatcherCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_PLAY_COUNT:
                            traktMostPWCShow.PlayCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COLLECTED_COUNT:
                            traktMostPWCShow.CollectedCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COLLECTOR_COUNT:
                            traktMostPWCShow.CollectorCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktMostPWCShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMostPWCShow;
            }

            return null;
        }
    }
}
