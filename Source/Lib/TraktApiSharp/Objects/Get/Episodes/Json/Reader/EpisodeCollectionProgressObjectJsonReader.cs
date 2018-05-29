namespace TraktApiSharp.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCollectionProgressObjectJsonReader : AObjectJsonReader<ITraktEpisodeCollectionProgress>
    {
        public override async Task<ITraktEpisodeCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeCollectionProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER:
                            traktEpisodeCollectionProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED:
                            traktEpisodeCollectionProgress.Completed = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COLLECTED_AT:
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

            return await Task.FromResult(default(ITraktEpisodeCollectionProgress));
        }
    }
}
