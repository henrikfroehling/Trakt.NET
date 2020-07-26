namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPost>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostReader = new SyncRatingsPostObjectJsonReader();
                var syncRatingsPosts = new List<ITraktSyncRatingsPost>();
                ITraktSyncRatingsPost syncRatingsPost = await syncRatingsPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPost != null)
                {
                    syncRatingsPosts.Add(syncRatingsPost);
                    syncRatingsPost = await syncRatingsPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPost>));
        }
    }
}
