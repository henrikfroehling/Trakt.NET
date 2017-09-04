namespace TraktApiSharp.Objects.Post.Syncs.Responses.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Post.Responses.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseNotFoundGroupObjectJsonReader : IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup>
    {
        private const string PROPERTY_NAME_MOVIES = "movies";
        private const string PROPERTY_NAME_SHOWS = "shows";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public Task<ITraktSyncPostResponseNotFoundGroup> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncPostResponseNotFoundGroup));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncPostResponseNotFoundGroup> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncPostResponseNotFoundGroup));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_MOVIES:
                            syncPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOWS:
                            syncPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
                            syncPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
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
