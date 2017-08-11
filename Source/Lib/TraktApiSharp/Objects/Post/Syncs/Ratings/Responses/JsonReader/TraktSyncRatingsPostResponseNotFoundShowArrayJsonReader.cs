namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktSyncRatingsPostResponseNotFoundShowArrayJsonReader : ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundShowObjectReader = new TraktSyncRatingsPostResponseNotFoundShowObjectJsonReader();
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
