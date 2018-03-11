namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPlaybackProgressItemArrayJsonReader : AArrayJsonReader<ITraktSyncPlaybackProgressItem>
    {
        public override async Task<IEnumerable<ITraktSyncPlaybackProgressItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
