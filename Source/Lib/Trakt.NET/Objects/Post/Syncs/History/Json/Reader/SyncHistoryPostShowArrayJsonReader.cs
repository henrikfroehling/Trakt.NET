namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostShowArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryPostShow>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostShowReader = new SyncHistoryPostShowObjectJsonReader();
                var syncHistoryPostShows = new List<ITraktSyncHistoryPostShow>();
                ITraktSyncHistoryPostShow syncHistoryPostShow = await syncHistoryPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostShow != null)
                {
                    syncHistoryPostShows.Add(syncHistoryPostShow);
                    syncHistoryPostShow = await syncHistoryPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShow>));
        }
    }
}
