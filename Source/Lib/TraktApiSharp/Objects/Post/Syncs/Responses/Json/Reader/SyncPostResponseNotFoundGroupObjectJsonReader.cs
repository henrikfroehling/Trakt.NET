namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncPostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncPostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new PostResponseNotFoundMovieArrayJsonReader();
                var notFoundShowsReader = new PostResponseNotFoundShowArrayJsonReader();
                var notFoundSeasonsReader = new PostResponseNotFoundSeasonArrayJsonReader();
                var notFoundEpisodesReader = new PostResponseNotFoundEpisodeArrayJsonReader();
                ITraktSyncPostResponseNotFoundGroup syncPostResponseNotFoundGroup = new TraktSyncPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES:
                            syncPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS:
                            syncPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS:
                            syncPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES:
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
