namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader : IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundEpisodeObjectReader = new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();
                //var syncRatingsPostResponseNotFoundEpisodeReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundEpisode>>();
                var syncRatingsPostResponseNotFoundEpisodes = new List<ITraktSyncRatingsPostResponseNotFoundEpisode>();

                //syncRatingsPostResponseNotFoundEpisodeReadingTasks.Add(syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundEpisode syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundEpisode != null)
                {
                    syncRatingsPostResponseNotFoundEpisodes.Add(syncRatingsPostResponseNotFoundEpisode);
                    //syncRatingsPostResponseNotFoundEpisodeReadingTasks.Add(syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundEpisodes = await Task.WhenAll(syncRatingsPostResponseNotFoundEpisodeReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>)readSyncRatingsPostResponseNotFoundEpisodes.GetEnumerator();
                return syncRatingsPostResponseNotFoundEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));
        }
    }
}
