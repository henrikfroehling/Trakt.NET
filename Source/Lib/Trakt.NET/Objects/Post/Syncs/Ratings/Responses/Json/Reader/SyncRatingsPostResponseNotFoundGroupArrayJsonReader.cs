namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundGroupArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundGroupReader = new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();
                var syncRatingsPostResponseNotFoundGroups = new List<ITraktSyncRatingsPostResponseNotFoundGroup>();
                ITraktSyncRatingsPostResponseNotFoundGroup syncRatingsPostResponseNotFoundGroup = await syncRatingsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundGroup != null)
                {
                    syncRatingsPostResponseNotFoundGroups.Add(syncRatingsPostResponseNotFoundGroup);
                    syncRatingsPostResponseNotFoundGroup = await syncRatingsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponseNotFoundGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundGroup>));
        }
    }
}
