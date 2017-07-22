namespace TraktApiSharp.Objects.Get.Collections.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCollectionMovieArrayJsonReader : ITraktArrayJsonReader<ITraktCollectionMovie>
    {
        public Task<IEnumerable<ITraktCollectionMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCollectionMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCollectionMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var calendarMovieReader = new TraktCollectionMovieObjectJsonReader();
                //var calendarMovieReadingTasks = new List<Task<ITraktCollectionMovie>>();
                var calendarMovies = new List<ITraktCollectionMovie>();

                //calendarMovieReadingTasks.Add(calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionMovie calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (calendarMovie != null)
                {
                    calendarMovies.Add(calendarMovie);
                    //calendarMovieReadingTasks.Add(calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    calendarMovie = await calendarMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionMovies = await Task.WhenAll(calendarMovieReadingTasks);
                //return (IEnumerable<ITraktCollectionMovie>)readCollectionMovies.GetEnumerator();
                return calendarMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));
        }
    }
}
