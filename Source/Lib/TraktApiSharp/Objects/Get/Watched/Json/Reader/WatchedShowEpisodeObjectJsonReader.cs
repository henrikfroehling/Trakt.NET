namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktWatchedShowEpisode>
    {
        public override async Task<ITraktWatchedShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktWatchedShowEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktWatchedShowEpisode traktWatchedShowEpisode = new TraktWatchedShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.WATCHED_SHOW_EPISODE_PROPERTY_NAME_NUMBER:
                            traktWatchedShowEpisode.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.WATCHED_SHOW_EPISODE_PROPERTY_NAME_PLAYS:
                            traktWatchedShowEpisode.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.WATCHED_SHOW_EPISODE_PROPERTY_NAME_LAST_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchedShowEpisode.LastWatchedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchedShowEpisode;
            }

            return await Task.FromResult(default(ITraktWatchedShowEpisode));
        }
    }
}
