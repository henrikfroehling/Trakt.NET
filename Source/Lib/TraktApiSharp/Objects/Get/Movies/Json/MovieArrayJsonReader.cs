namespace TraktApiSharp.Objects.Get.Movies.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieArrayJsonReader : IArrayJsonReader<ITraktMovie>
    {
        public Task<IEnumerable<ITraktMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReader = new MovieObjectJsonReader();
                //var traktMovieReadingTasks = new List<Task<ITraktMovie>>();
                var traktMovies = new List<ITraktMovie>();

                //traktMovieReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovie traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovie != null)
                {
                    traktMovies.Add(traktMovie);
                    //traktMovieReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovies = await Task.WhenAll(traktMovieReadingTasks);
                //return (IEnumerable<ITraktMovie>)readMovies.GetEnumerator();
                return traktMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovie>));
        }
    }
}
