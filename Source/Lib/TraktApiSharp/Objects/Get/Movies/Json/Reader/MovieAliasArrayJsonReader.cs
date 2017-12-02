namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieAliasArrayJsonReader : IArrayJsonReader<ITraktMovieAlias>
    {
        public Task<IEnumerable<ITraktMovieAlias>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMovieAlias>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMovieAlias>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMovieAlias>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMovieAlias>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieAliasReader = new MovieAliasObjectJsonReader();
                //var traktMovieAliasReadingTasks = new List<Task<ITraktMovieAlias>>();
                var traktMovieAliass = new List<ITraktMovieAlias>();

                //traktMovieAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieAlias traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieAlias != null)
                {
                    traktMovieAliass.Add(traktMovieAlias);
                    //traktMovieAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieAliass = await Task.WhenAll(traktMovieAliasReadingTasks);
                //return (IEnumerable<ITraktMovieAlias>)readMovieAliass.GetEnumerator();
                return traktMovieAliass;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));
        }
    }
}
