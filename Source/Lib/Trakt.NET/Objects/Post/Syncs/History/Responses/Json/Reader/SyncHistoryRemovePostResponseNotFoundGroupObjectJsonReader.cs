namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncHistoryRemovePostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
                var notFoundShowsReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
                var notFoundSeasonsReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
                var notFoundEpisodesReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();
                ITraktSyncHistoryRemovePostResponseNotFoundGroup syncHistoryRemovePostResponseNotFoundGroup = new TraktSyncHistoryRemovePostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncHistoryRemovePostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncHistoryRemovePostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            syncHistoryRemovePostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncHistoryRemovePostResponseNotFoundGroup.Episodes = await notFoundEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryRemovePostResponseNotFoundGroup.HistoryIds = await JsonReaderHelper.ReadUnsignedLongArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostResponseNotFoundGroup));
        }
    }
}
