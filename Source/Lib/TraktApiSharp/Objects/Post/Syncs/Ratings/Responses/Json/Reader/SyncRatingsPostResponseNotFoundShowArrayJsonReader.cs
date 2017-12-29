namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundShowArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundShowObjectReader = new SyncRatingsPostResponseNotFoundShowObjectJsonReader();
                //var syncRatingsPostResponseNotFoundShowReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundShow>>();
                var syncRatingsPostResponseNotFoundShows = new List<ITraktSyncRatingsPostResponseNotFoundShow>();

                //syncRatingsPostResponseNotFoundShowReadingTasks.Add(syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundShow syncRatingsPostResponseNotFoundShow = await syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundShow != null)
                {
                    syncRatingsPostResponseNotFoundShows.Add(syncRatingsPostResponseNotFoundShow);
                    //syncRatingsPostResponseNotFoundShowReadingTasks.Add(syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundShow = await syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundShows = await Task.WhenAll(syncRatingsPostResponseNotFoundShowReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>)readSyncRatingsPostResponseNotFoundShows.GetEnumerator();
                return syncRatingsPostResponseNotFoundShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));
        }
    }
}
