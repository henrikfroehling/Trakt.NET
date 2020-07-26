namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncRatingsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var postResponseMoviesReader = new ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie>();
                var postResponseShowsReader = new ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow>();
                var postResponseSeasonsReader = new ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason>();
                var postResponseEpisodesReader = new ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>();
                ITraktSyncRatingsPostResponseNotFoundGroup syncRatingsPostResponseNotFoundGroup = new TraktSyncRatingsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncRatingsPostResponseNotFoundGroup.Movies = await postResponseMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncRatingsPostResponseNotFoundGroup.Shows = await postResponseShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            syncRatingsPostResponseNotFoundGroup.Seasons = await postResponseSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncRatingsPostResponseNotFoundGroup.Episodes = await postResponseEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundGroup));
        }
    }
}
