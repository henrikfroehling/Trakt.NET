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
                //var syncCollectionPostResponseReadingTasks = new List<Task<ITraktSyncCollectionPostResponse>>();
                var syncCollectionPostResponses = new List<ITraktSyncCollectionPostResponse>();

                //syncCollectionPostResponseReadingTasks.Add(syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncCollectionPostResponse syncCollectionPostResponse = await syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostResponse != null)
                {
                    syncCollectionPostResponses.Add(syncCollectionPostResponse);
                    //syncCollectionPostResponseReadingTasks.Add(syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncCollectionPostResponse = await syncCollectionPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncCollectionPostResponses = await Task.WhenAll(syncCollectionPostResponseReadingTasks);
                //return (IEnumerable<ITraktSyncCollectionPostResponse>)readSyncCollectionPostResponses.GetEnumerator();
                return syncCollectionPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostResponse>));
        }
    }
}
