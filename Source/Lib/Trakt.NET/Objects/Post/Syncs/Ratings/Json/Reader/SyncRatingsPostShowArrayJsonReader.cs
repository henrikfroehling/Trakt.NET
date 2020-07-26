namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostShowArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPostShow>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostShowReader = new SyncRatingsPostShowObjectJsonReader();
                var syncRatingsPostShows = new List<ITraktSyncRatingsPostShow>();
                ITraktSyncRatingsPostShow syncRatingsPostShow = await syncRatingsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostShow != null)
                {
                    syncRatingsPostShows.Add(syncRatingsPostShow);
                    syncRatingsPostShow = await syncRatingsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShow>));
        }
    }
}
