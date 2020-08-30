namespace TraktNet.Objects.Post.Syncs.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncPostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
                var notFoundShowsReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
                var notFoundSeasonsReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
                var notFoundEpisodesReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();
                ITraktSyncPostResponseNotFoundGroup syncPostResponseNotFoundGroup = new TraktSyncPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            syncPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncPostResponseNotFoundGroup.Episodes = await notFoundEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktSyncPostResponseNotFoundGroup));
        }
    }
}
