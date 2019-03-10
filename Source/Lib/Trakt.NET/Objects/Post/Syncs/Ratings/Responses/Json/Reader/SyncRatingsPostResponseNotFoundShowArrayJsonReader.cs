namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
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
                var syncRatingsPostResponseNotFoundShows = new List<ITraktSyncRatingsPostResponseNotFoundShow>();
                ITraktSyncRatingsPostResponseNotFoundShow syncRatingsPostResponseNotFoundShow = await syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundShow != null)
                {
                    syncRatingsPostResponseNotFoundShows.Add(syncRatingsPostResponseNotFoundShow);
                    syncRatingsPostResponseNotFoundShow = await syncRatingsPostResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponseNotFoundShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));
        }
    }
}
