namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedMovieArrayJsonReader : IArrayJsonReader<ITraktWatchedMovie>
    {
        public Task<IEnumerable<ITraktWatchedMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktWatchedMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktWatchedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedMovieReader = new WatchedMovieObjectJsonReader();
                //var watchedMovieReadingTasks = new List<Task<ITraktWatchedMovie>>();
                var watchedMovies = new List<ITraktWatchedMovie>();

                //watchedMovieReadingTasks.Add(watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedMovie watchedMovie = await watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedMovie != null)
                {
                    watchedMovies.Add(watchedMovie);
                    //watchedMovieReadingTasks.Add(watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedMovie = await watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedMovies = await Task.WhenAll(watchedMovieReadingTasks);
                //return (IEnumerable<ITraktWatchedMovie>)readWatchedMovies.GetEnumerator();
                return watchedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));
        }
    }
}
