namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowSeasonArrayReader : AArrayJsonReader<ITraktSyncCollectionPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostShowSeasonReader = new SyncCollectionPostShowSeasonObjectJsonReader();
                var syncCollectionPostShowSeasons = new List<ITraktSyncCollectionPostShowSeason>();
                ITraktSyncCollectionPostShowSeason syncCollectionPostShowSeason = await syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShowSeason != null)
                {
                    syncCollectionPostShowSeasons.Add(syncCollectionPostShowSeason);
                    syncCollectionPostShowSeason = await syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowSeason>));
        }
    }
}
