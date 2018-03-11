namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonObjectJsonReader : AObjectJsonReader<ITraktWatchedShowSeason>
    {
        public override async Task<ITraktWatchedShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktWatchedShowSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var watchedShowEpisodeArrayReader = new WatchedShowEpisodeArrayJsonReader();

                ITraktWatchedShowSeason traktWatchedShowSeason = new TraktWatchedShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_NUMBER:
                            traktWatchedShowSeason.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_EPISODES:
                            traktWatchedShowSeason.Episodes = await watchedShowEpisodeArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchedShowSeason;
            }

            return await Task.FromResult(default(ITraktWatchedShowSeason));
        }
    }
}
