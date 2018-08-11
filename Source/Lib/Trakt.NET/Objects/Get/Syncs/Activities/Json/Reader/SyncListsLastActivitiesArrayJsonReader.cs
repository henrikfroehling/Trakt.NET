namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncListsLastActivitiesArrayJsonReader : AArrayJsonReader<ITraktSyncListsLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncListsLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncListsLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncListsLastActivitiesReader = new SyncListsLastActivitiesObjectJsonReader();
                var syncListsLastActivitiess = new List<ITraktSyncListsLastActivities>();
                ITraktSyncListsLastActivities syncListsLastActivities = await syncListsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncListsLastActivities != null)
                {
                    syncListsLastActivitiess.Add(syncListsLastActivities);
                    syncListsLastActivities = await syncListsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncListsLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncListsLastActivities>));
        }
    }
}
