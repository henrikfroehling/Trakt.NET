namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncEpisodesLastActivitiesArrayJsonReader : AArrayJsonReader<ITraktSyncEpisodesLastActivities>
    {
        public override async Task<IEnumerable<ITraktSyncEpisodesLastActivities>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncEpisodesLastActivities>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncEpisodesLastActivitiesReader = new SyncEpisodesLastActivitiesObjectJsonReader();
                var syncEpisodesLastActivitiess = new List<ITraktSyncEpisodesLastActivities>();
                ITraktSyncEpisodesLastActivities syncEpisodesLastActivities = await syncEpisodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncEpisodesLastActivities != null)
                {
                    syncEpisodesLastActivitiess.Add(syncEpisodesLastActivities);
                    syncEpisodesLastActivities = await syncEpisodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncEpisodesLastActivitiess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncEpisodesLastActivities>));
        }
    }
}
