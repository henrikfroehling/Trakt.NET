namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncLastActivitiesArrayJsonReader : AArrayJsonReader<ITraktSyncLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncLastActivitiesReader = new SyncLastActivitiesObjectJsonReader();
                var syncLastActivitiess = new List<ITraktSyncLastActivities>();
                ITraktSyncLastActivities syncLastActivities = await syncLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncLastActivities != null)
                {
                    syncLastActivitiess.Add(syncLastActivities);
                    syncLastActivities = await syncLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncLastActivities>));
        }
    }
}
