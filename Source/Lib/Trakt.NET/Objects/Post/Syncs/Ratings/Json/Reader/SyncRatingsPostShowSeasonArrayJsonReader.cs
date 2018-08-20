namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostShowSeasonArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostShowSeasonReader = new SyncRatingsPostShowSeasonObjectJsonReader();
                var syncRatingsPostShowSeasons = new List<ITraktSyncRatingsPostShowSeason>();
                ITraktSyncRatingsPostShowSeason syncRatingsPostShowSeason = await syncRatingsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostShowSeason != null)
                {
                    syncRatingsPostShowSeasons.Add(syncRatingsPostShowSeason);
                    syncRatingsPostShowSeason = await syncRatingsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShowSeason>));
        }
    }
}
