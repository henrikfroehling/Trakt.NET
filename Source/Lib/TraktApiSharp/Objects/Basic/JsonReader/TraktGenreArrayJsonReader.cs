namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktGenreArrayJsonReader : ITraktArrayJsonReader<ITraktGenre>
    {
        public Task<IEnumerable<ITraktGenre>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktGenre>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktGenre>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktGenre>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktGenre>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktGenre>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var genreReader = new TraktGenreObjectJsonReader();
                //var genreReadingTasks = new List<Task<ITraktGenre>>();
                var genres = new List<ITraktGenre>();

                //genreReadingTasks.Add(genreReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktGenre genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (genre != null)
                {
                    genres.Add(genre);
                    //genreReadingTasks.Add(genreReader.ReadObjectAsync(jsonReader, cancellationToken));
                    genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readGenres = await Task.WhenAll(genreReadingTasks);
                //return (IEnumerable<ITraktGenre>)readGenres.GetEnumerator();
                return genres;
            }

            return await Task.FromResult(default(IEnumerable<ITraktGenre>));
        }
    }
}
