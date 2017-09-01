namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieReleaseArrayJsonReader : IArrayJsonReader<ITraktMovieRelease>
    {
        public Task<IEnumerable<ITraktMovieRelease>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMovieRelease>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMovieRelease>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMovieRelease>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMovieRelease>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieRelease>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReleaseReader = new TraktMovieReleaseObjectJsonReader();
                //var traktMovieReleaseReadingTasks = new List<Task<ITraktMovieRelease>>();
                var traktMovieReleases = new List<ITraktMovieRelease>();

                //traktMovieReleaseReadingTasks.Add(movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieRelease traktMovieRelease = await movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieRelease != null)
                {
                    traktMovieReleases.Add(traktMovieRelease);
                    //traktMovieReleaseReadingTasks.Add(movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieRelease = await movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieReleases = await Task.WhenAll(traktMovieReleaseReadingTasks);
                //return (IEnumerable<ITraktMovieRelease>)readMovieReleases.GetEnumerator();
                return traktMovieReleases;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieRelease>));
        }
    }
}
