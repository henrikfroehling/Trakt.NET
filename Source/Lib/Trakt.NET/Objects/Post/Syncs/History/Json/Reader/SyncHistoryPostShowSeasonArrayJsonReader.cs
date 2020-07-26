namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostShowSeasonArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostShowSeasonReader = new SyncHistoryPostShowSeasonObjectJsonReader();
                var syncHistoryPostShowSeasons = new List<ITraktSyncHistoryPostShowSeason>();
                ITraktSyncHistoryPostShowSeason syncHistoryPostShowSeason = await syncHistoryPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostShowSeason != null)
                {
                    syncHistoryPostShowSeasons.Add(syncHistoryPostShowSeason);
                    syncHistoryPostShowSeason = await syncHistoryPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostShowSeason>));
        }
    }
}
