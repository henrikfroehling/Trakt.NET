namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCollectionProgressObjectJsonReader : AObjectJsonReader<ITraktShowCollectionProgress>
    {
        public override async Task<ITraktShowCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowCollectionProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonsArrayReader = new SeasonArrayJsonReader();
                var seasonCollectionProgressArrayReader = new SeasonCollectionProgressArrayJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktShowCollectionProgress traktShowCollectionProgress = new TraktShowCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_AIRED:
                            traktShowCollectionProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMPLETED:
                            traktShowCollectionProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LAST_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowCollectionProgress.LastCollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            traktShowCollectionProgress.Seasons = await seasonCollectionProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_HIDDEN_SEASONS:
                            traktShowCollectionProgress.HiddenSeasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NEXT_EPISODE:
                            traktShowCollectionProgress.NextEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LAST_EPISODE:
                            traktShowCollectionProgress.LastEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowCollectionProgress;
            }

            return await Task.FromResult(default(ITraktShowCollectionProgress));
        }
    }
}
