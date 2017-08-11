namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktSyncRatingsPostResponseNotFoundMovieArrayJsonReader : ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundMovieObjectReader = new TraktSyncRatingsPostResponseNotFoundMovieObjectJsonReader();
                //var syncRatingsPostResponseNotFoundMovieReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundMovie>>();
                var syncRatingsPostResponseNotFoundMovies = new List<ITraktSyncRatingsPostResponseNotFoundMovie>();

                //syncRatingsPostResponseNotFoundMovieReadingTasks.Add(syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundMovie syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundMovie != null)
                {
                    syncRatingsPostResponseNotFoundMovies.Add(syncRatingsPostResponseNotFoundMovie);
                    //syncRatingsPostResponseNotFoundMovieReadingTasks.Add(syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundMovies = await Task.WhenAll(syncRatingsPostResponseNotFoundMovieReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>)readSyncRatingsPostResponseNotFoundMovies.GetEnumerator();
                return syncRatingsPostResponseNotFoundMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));
        }
    }
}
