namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader
{
    using Get.Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader : IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_IDS = "ids";

        public Task<ITraktSyncRatingsPostResponseNotFoundEpisode> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncRatingsPostResponseNotFoundEpisode> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncRatingsPostResponseNotFoundEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncRatingsPostResponseNotFoundEpisode syncRatingsPostResponseNotFoundEpisode = new TraktSyncRatingsPostResponseNotFoundEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATING:
                            syncRatingsPostResponseNotFoundEpisode.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_IDS:
                            syncRatingsPostResponseNotFoundEpisode.Ids = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundEpisode;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));
        }
    }
}
