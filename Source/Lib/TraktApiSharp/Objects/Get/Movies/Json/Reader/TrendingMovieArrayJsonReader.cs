namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingMovieArrayJsonReader : AArrayJsonReader<ITraktTrendingMovie>
    {
        public override async Task<IEnumerable<ITraktTrendingMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
