namespace TraktApiSharp.Objects.Get.Seasons.Json.Reader
{
    using Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonWatchedProgressObjectJsonReader : AObjectJsonReader<ITraktSeasonWatchedProgress>
    {
        public override async Task<ITraktSeasonWatchedProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSeasonWatchedProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeWatchedProgressArrayReader = new EpisodeWatchedProgressArrayJsonReader();
                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SEASON_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER:
                            traktSeasonWatchedProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_WATCHED_PROGRESS_PROPERTY_NAME_AIRED:
                            traktSeasonWatchedProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED:
                            traktSeasonWatchedProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_WATCHED_PROGRESS_PROPERTY_NAME_EPISODES:
                            traktSeasonWatchedProgress.Episodes = await episodeWatchedProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSeasonWatchedProgress;
            }

            return await Task.FromResult(default(ITraktSeasonWatchedProgress));
        }
    }
}
