namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingMovieArrayJsonReader : IArrayJsonReader<ITraktTrendingMovie>
    {
        public Task<IEnumerable<ITraktTrendingMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktTrendingMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktTrendingMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktTrendingMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktTrendingMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktTrendingMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var trendingMovieReader = new TrendingMovieObjectJsonReader();
                //var traktTrendingMovieReadingTasks = new List<Task<ITraktTrendingMovie>>();
                var traktTrendingMovies = new List<ITraktTrendingMovie>();

                //traktTrendingMovieReadingTasks.Add(trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktTrendingMovie traktTrendingMovie = await trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktTrendingMovie != null)
                {
                    traktTrendingMovies.Add(traktTrendingMovie);
                    //traktTrendingMovieReadingTasks.Add(trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktTrendingMovie = await trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readTrendingMovies = await Task.WhenAll(traktTrendingMovieReadingTasks);
                //return (IEnumerable<ITraktTrendingMovie>)readTrendingMovies.GetEnumerator();
                return traktTrendingMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktTrendingMovie>));
        }
    }
}
