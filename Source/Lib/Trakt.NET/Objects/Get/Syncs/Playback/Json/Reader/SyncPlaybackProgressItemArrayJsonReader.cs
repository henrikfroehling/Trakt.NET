namespace TraktNet.Objects.Get.Syncs.Playback.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPlaybackProgressItemArrayJsonReader : ArrayJsonReader<ITraktSyncPlaybackProgressItem>
    {
        public override async Task<IEnumerable<ITraktSyncPlaybackProgressItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var playbackProgressItemReader = new SyncPlaybackProgressItemObjectJsonReader();
                var playbackProgressItems = new List<ITraktSyncPlaybackProgressItem>();
                ITraktSyncPlaybackProgressItem playbackProgressItem = await playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (playbackProgressItem != null)
                {
                    playbackProgressItems.Add(playbackProgressItem);
                    playbackProgressItem = await playbackProgressItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return playbackProgressItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncPlaybackProgressItem>));
        }
    }
}
