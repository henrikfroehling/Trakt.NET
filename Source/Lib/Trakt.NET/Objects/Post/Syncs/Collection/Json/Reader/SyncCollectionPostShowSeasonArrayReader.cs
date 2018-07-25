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
                //var syncCollectionPostShowSeasonReadingTasks = new List<Task<ITraktSyncCollectionPostShowSeason>>();
                var syncCollectionPostShowSeasons = new List<ITraktSyncCollectionPostShowSeason>();

                //syncCollectionPostShowSeasonReadingTasks.Add(syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncCollectionPostShowSeason syncCollectionPostShowSeason = await syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShowSeason != null)
                {
                    syncCollectionPostShowSeasons.Add(syncCollectionPostShowSeason);
                    //syncCollectionPostShowSeasonReadingTasks.Add(syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncCollectionPostShowSeason = await syncCollectionPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncCollectionPostShowSeasons = await Task.WhenAll(syncCollectionPostShowSeasonReadingTasks);
                //return (IEnumerable<ITraktSyncCollectionPostShowSeason>)readSyncCollectionPostShowSeasons.GetEnumerator();
                return syncCollectionPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowSeason>));
        }
    }
}
