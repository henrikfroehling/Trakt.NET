namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktMostAnticipatedMovieArrayJsonReader : ITraktArrayJsonReader<ITraktMostAnticipatedMovie>
    {
        public Task<IEnumerable<ITraktMostAnticipatedMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMostAnticipatedMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMostAnticipatedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostAnticipatedMovieReader = new TraktMostAnticipatedMovieObjectJsonReader();
                //var traktMostAnticipatedMovieReadingTasks = new List<Task<ITraktMostAnticipatedMovie>>();
                var traktMostAnticipatedMovies = new List<ITraktMostAnticipatedMovie>();

                //traktMostAnticipatedMovieReadingTasks.Add(mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostAnticipatedMovie traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedMovie != null)
                {
                    traktMostAnticipatedMovies.Add(traktMostAnticipatedMovie);
                    //traktMostAnticipatedMovieReadingTasks.Add(mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostAnticipatedMovies = await Task.WhenAll(traktMostAnticipatedMovieReadingTasks);
                //return (IEnumerable<ITraktMostAnticipatedMovie>)readMostAnticipatedMovies.GetEnumerator();
                return traktMostAnticipatedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));
        }
    }
}
