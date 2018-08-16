namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostShowEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncHistoryPostShowEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostShowEpisodeReader = new SyncHistoryPostShowEpisodeObjectJsonReader();
                var syncHistoryPostShowEpisodes = new List<ITraktSyncHistoryPostShowEpisode>();
                ITraktSyncHistoryPostShowEpisode syncHistoryPostShowEpisode = await syncHistoryPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostShowEpisode != null)
                {
                    syncHistoryPostShowEpisodes.Add(syncHistoryPostShowEpisode);
                    syncHistoryPostShowEpisode = await syncHistoryPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShowEpisode>));
        }
    }
}
