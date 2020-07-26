namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostEpisodeArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryPostEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostEpisodeReader = new SyncHistoryPostEpisodeObjectJsonReader();
                var syncHistoryPostEpisodes = new List<ITraktSyncHistoryPostEpisode>();
                ITraktSyncHistoryPostEpisode syncHistoryPostEpisode = await syncHistoryPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostEpisode != null)
                {
                    syncHistoryPostEpisodes.Add(syncHistoryPostEpisode);
                    syncHistoryPostEpisode = await syncHistoryPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostEpisode>));
        }
    }
}
