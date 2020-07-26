namespace TraktNet.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedMovieArrayJsonReader : ArrayJsonReader<ITraktWatchedMovie>
    {
        public override async Task<IEnumerable<ITraktWatchedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedMovieReader = new WatchedMovieObjectJsonReader();
                var watchedMovies = new List<ITraktWatchedMovie>();
                ITraktWatchedMovie watchedMovie = await watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedMovie != null)
                {
                    watchedMovies.Add(watchedMovie);
                    watchedMovie = await watchedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return watchedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedMovie>));
        }
    }
}
