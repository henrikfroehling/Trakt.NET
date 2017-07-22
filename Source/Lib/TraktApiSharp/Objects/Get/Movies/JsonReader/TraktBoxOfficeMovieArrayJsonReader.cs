namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktBoxOfficeMovieArrayJsonReader : ITraktArrayJsonReader<ITraktBoxOfficeMovie>
    {
        public Task<IEnumerable<ITraktBoxOfficeMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktBoxOfficeMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktBoxOfficeMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var boxOfficeMovieReader = new TraktBoxOfficeMovieObjectJsonReader();
                //var traktBoxOfficeMovieReadingTasks = new List<Task<ITraktBoxOfficeMovie>>();
                var traktBoxOfficeMovies = new List<ITraktBoxOfficeMovie>();

                //traktBoxOfficeMovieReadingTasks.Add(boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktBoxOfficeMovie traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktBoxOfficeMovie != null)
                {
                    traktBoxOfficeMovies.Add(traktBoxOfficeMovie);
                    //traktBoxOfficeMovieReadingTasks.Add(boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readBoxOfficeMovies = await Task.WhenAll(traktBoxOfficeMovieReadingTasks);
                //return (IEnumerable<ITraktBoxOfficeMovie>)readBoxOfficeMovies.GetEnumerator();
                return traktBoxOfficeMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));
        }
    }
}
