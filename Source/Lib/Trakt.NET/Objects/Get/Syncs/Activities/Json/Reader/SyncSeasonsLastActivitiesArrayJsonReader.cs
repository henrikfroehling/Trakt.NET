namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncSeasonsLastActivitiesArrayJsonReader : ArrayJsonReader<ITraktSyncSeasonsLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncSeasonsLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncSeasonsLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncSeasonsLastActivitiesReader = new SyncSeasonsLastActivitiesObjectJsonReader();
                var syncSeasonsLastActivitiess = new List<ITraktSyncSeasonsLastActivities>();
                ITraktSyncSeasonsLastActivities syncSeasonsLastActivities = await syncSeasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncSeasonsLastActivities != null)
                {
                    syncSeasonsLastActivitiess.Add(syncSeasonsLastActivities);
                    syncSeasonsLastActivities = await syncSeasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncSeasonsLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncSeasonsLastActivities>));
        }
    }
}
