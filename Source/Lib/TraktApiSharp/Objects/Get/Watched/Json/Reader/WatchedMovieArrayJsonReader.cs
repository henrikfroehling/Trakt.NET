namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedMovieArrayJsonReader : AArrayJsonReader<ITraktWatchedMovie>
    {
        public override async Task<IEnumerable<ITraktWatchedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
