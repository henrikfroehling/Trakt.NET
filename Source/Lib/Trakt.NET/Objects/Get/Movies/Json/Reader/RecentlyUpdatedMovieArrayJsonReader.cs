namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedMovieArrayJsonReader : AArrayJsonReader<ITraktRecentlyUpdatedMovie>
    {
        public override async Task<IEnumerable<ITraktRecentlyUpdatedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var recentlyUpdatedMovieReader = new RecentlyUpdatedMovieObjectJsonReader();
                var traktRecentlyUpdatedMovies = new List<ITraktRecentlyUpdatedMovie>();
                ITraktRecentlyUpdatedMovie traktRecentlyUpdatedMovie = await recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktRecentlyUpdatedMovie != null)
                {
                    traktRecentlyUpdatedMovies.Add(traktRecentlyUpdatedMovie);
                    traktRecentlyUpdatedMovie = await recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktRecentlyUpdatedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));
        }
    }
}
