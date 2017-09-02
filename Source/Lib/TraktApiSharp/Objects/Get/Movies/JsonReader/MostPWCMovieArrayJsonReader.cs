namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCMovieArrayJsonReader : IArrayJsonReader<ITraktMostPWCMovie>
    {
        public Task<IEnumerable<ITraktMostPWCMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMostPWCMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMostPWCMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostPWCMovieReader = new MostPWCMovieObjectJsonReader();
                //var traktMostPWCMovieReadingTasks = new List<Task<ITraktMostPWCMovie>>();
                var traktMostPWCMovies = new List<ITraktMostPWCMovie>();

                //traktMostPWCMovieReadingTasks.Add(mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostPWCMovie traktMostPWCMovie = await mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostPWCMovie != null)
                {
                    traktMostPWCMovies.Add(traktMostPWCMovie);
                    //traktMostPWCMovieReadingTasks.Add(mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostPWCMovie = await mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostPWCMovies = await Task.WhenAll(traktMostPWCMovieReadingTasks);
                //return (IEnumerable<ITraktMostPWCMovie>)readMostPWCMovies.GetEnumerator();
                return traktMostPWCMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));
        }
    }
}
