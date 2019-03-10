namespace TraktNet.Objects.Post.Syncs.Collection.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostResponseArrayJsonReader : AArrayJsonReader<ITraktSyncCollectionPostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostResponseReader = new SyncCollectionPostResponseObjectJsonReader();
                var syncCollectionPostResponses = new List<ITraktSyncCollectionPostResponse>();
                ITraktSyncCollectionPostResponse syncCollectionPostResponse = await syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostResponse != null)
                {
                    syncCollectionPostResponses.Add(syncCollectionPostResponse);
                    syncCollectionPostResponse = await syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostResponse>));
        }
    }
}
