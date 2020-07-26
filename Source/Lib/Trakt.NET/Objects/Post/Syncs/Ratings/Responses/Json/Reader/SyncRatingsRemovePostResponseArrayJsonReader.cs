namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsRemovePostResponseArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsRemovePostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsRemovePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsRemovePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsRemovePostResponseReader = new SyncRatingsRemovePostResponseObjectJsonReader();
                var syncRatingsRemovePostResponses = new List<ITraktSyncRatingsRemovePostResponse>();
                ITraktSyncRatingsRemovePostResponse syncRatingsRemovePostResponse = await syncRatingsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsRemovePostResponse != null)
                {
                    syncRatingsRemovePostResponses.Add(syncRatingsRemovePostResponse);
                    syncRatingsRemovePostResponse = await syncRatingsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsRemovePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsRemovePostResponse>));
        }
    }
}
