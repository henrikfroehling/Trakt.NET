namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowObjectJsonReader : AObjectJsonReader<ITraktMostPWCShow>
    {
        public override async Task<ITraktMostPWCShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
