namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktMovieTranslationArrayJsonReader : IArrayJsonReader<ITraktMovieTranslation>
    {
        public Task<IEnumerable<ITraktMovieTranslation>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMovieTranslation>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMovieTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieTranslationReader = new TraktMovieTranslationObjectJsonReader();
                //var traktMovieTranslationReadingTasks = new List<Task<ITraktMovieTranslation>>();
                var traktMovieTranslations = new List<ITraktMovieTranslation>();

                //traktMovieTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieTranslation traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieTranslation != null)
                {
                    traktMovieTranslations.Add(traktMovieTranslation);
                    //traktMovieTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieTranslations = await Task.WhenAll(traktMovieTranslationReadingTasks);
                //return (IEnumerable<ITraktMovieTranslation>)readMovieTranslations.GetEnumerator();
                return traktMovieTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));
        }
    }
}
