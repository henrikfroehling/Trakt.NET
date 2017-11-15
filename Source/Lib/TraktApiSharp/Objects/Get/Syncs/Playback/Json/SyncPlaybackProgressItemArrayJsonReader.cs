namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPlaybackProgressItemArrayJsonReader : IArrayJsonReader<ITraktSyncPlaybackProgressItem>
    {
        public Task<IEnumerable<ITraktSyncPlaybackProgressItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSyncPlaybackProgressItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSyncPlaybackProgressItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var playbackProgressItemReader = new SyncPlaybackProgressItemObjectJsonReader();
                //var playbackProgressItemReadingTasks = new List<Task<ITraktSyncPlaybackProgressItem>>();
                var playbackProgressItems = new List<ITraktSyncPlaybackProgressItem>();

                //playbackProgressItemReadingTasks.Add(playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncPlaybackProgressItem playbackProgressItem = await playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (playbackProgressItem != null)
                {
                    playbackProgressItems.Add(playbackProgressItem);
                    //playbackProgressItemReadingTasks.Add(playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    playbackProgressItem = await playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncPlaybackProgressItems = await Task.WhenAll(playbackProgressItemReadingTasks);
                //return (IEnumerable<ITraktSyncPlaybackProgressItem>)readSyncPlaybackProgressItems.GetEnumerator();
                return playbackProgressItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));
        }
    }
}
