namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCommentsLastActivitiesArrayJsonReader : ArrayJsonReader<ITraktSyncCommentsLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncCommentsLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCommentsLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCommentsLastActivitiesReader = new SyncCommentsLastActivitiesObjectJsonReader();
                var syncCommentsLastActivitiess = new List<ITraktSyncCommentsLastActivities>();
                ITraktSyncCommentsLastActivities syncCommentsLastActivities = await syncCommentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCommentsLastActivities != null)
                {
                    syncCommentsLastActivitiess.Add(syncCommentsLastActivities);
                    syncCommentsLastActivities = await syncCommentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCommentsLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCommentsLastActivities>));
        }
    }
}
