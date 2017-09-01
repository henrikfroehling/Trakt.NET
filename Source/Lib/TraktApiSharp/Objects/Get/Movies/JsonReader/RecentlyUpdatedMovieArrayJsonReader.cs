namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedMovieArrayJsonReader : IArrayJsonReader<ITraktRecentlyUpdatedMovie>
    {
        public Task<IEnumerable<ITraktRecentlyUpdatedMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktRecentlyUpdatedMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktRecentlyUpdatedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var recentlyUpdatedMovieReader = new TraktRecentlyUpdatedMovieObjectJsonReader();
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
