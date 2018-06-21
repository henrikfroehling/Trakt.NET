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
                //var traktRecentlyUpdatedMovieReadingTasks = new List<Task<ITraktRecentlyUpdatedMovie>>();
                var traktRecentlyUpdatedMovies = new List<ITraktRecentlyUpdatedMovie>();

                //traktRecentlyUpdatedMovieReadingTasks.Add(recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktRecentlyUpdatedMovie traktRecentlyUpdatedMovie = await recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktRecentlyUpdatedMovie != null)
                {
                    traktRecentlyUpdatedMovies.Add(traktRecentlyUpdatedMovie);
                    //traktRecentlyUpdatedMovieReadingTasks.Add(recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktRecentlyUpdatedMovie = await recentlyUpdatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readRecentlyUpdatedMovies = await Task.WhenAll(traktRecentlyUpdatedMovieReadingTasks);
                //return (IEnumerable<ITraktRecentlyUpdatedMovie>)readRecentlyUpdatedMovies.GetEnumerator();
                return traktRecentlyUpdatedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));
        }
    }
}
