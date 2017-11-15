namespace TraktApiSharp.Objects.Get.Watched.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowEpisodeArrayJsonReader : IArrayJsonReader<ITraktWatchedShowEpisode>
    {
        public Task<IEnumerable<ITraktWatchedShowEpisode>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktWatchedShowEpisode>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktWatchedShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowEpisodeObjectReader = new WatchedShowEpisodeObjectJsonReader();
                //var watchedShowEpisodeReadingTasks = new List<Task<ITraktWatchedShowEpisode>>();
                var watchedShowEpisodes = new List<ITraktWatchedShowEpisode>();

                //watchedShowEpisodeReadingTasks.Add(watchedShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedShowEpisode watchedShowEpisode = await watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShowEpisode != null)
                {
                    watchedShowEpisodes.Add(watchedShowEpisode);
                    //watchedShowEpisodeReadingTasks.Add(watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedShowEpisode = await watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedShowEpisodes = await Task.WhenAll(watchedShowEpisodeReadingTasks);
                //return (IEnumerable<ITraktWatchedShowEpisode>)readWatchedShowEpisodes.GetEnumerator();
                return watchedShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));
        }
    }
}
