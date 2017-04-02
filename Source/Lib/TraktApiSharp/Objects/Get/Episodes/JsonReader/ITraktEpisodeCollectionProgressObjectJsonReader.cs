namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktEpisodeCollectionProgressObjectJsonReader : ITraktObjectJsonReader<ITraktEpisodeCollectionProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_COLLECTED_AT = "collected_at";

        public Task<ITraktEpisodeCollectionProgress> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktEpisodeCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktEpisodeCollectionProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktEpisodeCollectionProgress.Completed = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktEpisodeCollectionProgress.CollectedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktEpisodeCollectionProgress;
            }

            return null;
        }
    }
}
