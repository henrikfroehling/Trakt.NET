namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncMoviesLastActivitiesArrayJsonReader : AArrayJsonReader<ITraktSyncMoviesLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncMoviesLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncMoviesLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncMoviesLastActivitiesReader = new SyncMoviesLastActivitiesObjectJsonReader();
                var syncMoviesLastActivitiess = new List<ITraktSyncMoviesLastActivities>();
                ITraktSyncMoviesLastActivities syncMoviesLastActivities = await syncMoviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncMoviesLastActivities != null)
                {
                    syncMoviesLastActivitiess.Add(syncMoviesLastActivities);
                    syncMoviesLastActivities = await syncMoviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncMoviesLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncMoviesLastActivities>));
        }
    }
}
