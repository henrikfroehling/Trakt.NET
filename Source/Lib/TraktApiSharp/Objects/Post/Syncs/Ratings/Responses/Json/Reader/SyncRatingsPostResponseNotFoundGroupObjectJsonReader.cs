namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundGroupObjectJsonReader : IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public Task<ITraktSyncRatingsPostResponseNotFoundGroup> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundGroup));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncRatingsPostResponseNotFoundGroup> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundGroup));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncRatingsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var postResponseMoviesReader = new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();
                var postResponseShowsReader = new SyncRatingsPostResponseNotFoundShowArrayJsonReader();
                var postResponseSeasonsReader = new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();
                var postResponseEpisodesReader = new SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
                ITraktSyncRatingsPostResponseNotFoundGroup syncRatingsPostResponseNotFoundGroup = new TraktSyncRatingsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES:
                            syncRatingsPostResponseNotFoundGroup.Movies = await postResponseMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS:
                            syncRatingsPostResponseNotFoundGroup.Shows = await postResponseShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS:
                            syncRatingsPostResponseNotFoundGroup.Seasons = await postResponseSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES:
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
