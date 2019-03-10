namespace TraktNet.Objects.Get.Movies.Json.Reader
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
                var traktTrendingMovies = new List<ITraktTrendingMovie>();
                ITraktTrendingMovie traktTrendingMovie = await trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktTrendingMovie != null)
                {
                    traktTrendingMovies.Add(traktTrendingMovie);
                    traktTrendingMovie = await trendingMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktTrendingMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktTrendingMovie>));
        }
    }
}
