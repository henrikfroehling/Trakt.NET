namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeWatchedProgressObjectJsonReader : AObjectJsonReader<ITraktEpisodeWatchedProgress>
    {
        public override async Task<ITraktEpisodeWatchedProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeWatchedProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER:
                            traktEpisodeWatchedProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED:
                            traktEpisodeWatchedProgress.Completed = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_LAST_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktEpisodeWatchedProgress.LastWatchedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktEpisodeWatchedProgress;
            }

            return await Task.FromResult(default(ITraktEpisodeWatchedProgress));
        }
    }
}
