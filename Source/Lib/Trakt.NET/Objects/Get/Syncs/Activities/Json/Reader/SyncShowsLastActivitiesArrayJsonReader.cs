namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncShowsLastActivitiesArrayJsonReader : AArrayJsonReader<ITraktSyncShowsLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncShowsLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncShowsLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncShowsLastActivitiesReader = new SyncShowsLastActivitiesObjectJsonReader();
                var syncShowsLastActivitiess = new List<ITraktSyncShowsLastActivities>();
                ITraktSyncShowsLastActivities syncShowsLastActivities = await syncShowsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncShowsLastActivities != null)
                {
                    syncShowsLastActivitiess.Add(syncShowsLastActivities);
                    syncShowsLastActivities = await syncShowsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncShowsLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncShowsLastActivities>));
        }
    }
}
