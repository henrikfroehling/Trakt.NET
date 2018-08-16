namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseReader = new SyncRatingsPostResponseObjectJsonReader();
                var syncRatingsPostResponses = new List<ITraktSyncRatingsPostResponse>();
                ITraktSyncRatingsPostResponse syncRatingsPostResponse = await syncRatingsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponse != null)
                {
                    syncRatingsPostResponses.Add(syncRatingsPostResponse);
                    syncRatingsPostResponse = await syncRatingsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponse>));
        }
    }
}
