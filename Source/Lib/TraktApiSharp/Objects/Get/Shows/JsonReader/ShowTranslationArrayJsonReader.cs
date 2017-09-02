namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowTranslationArrayJsonReader : IArrayJsonReader<ITraktShowTranslation>
    {
        public Task<IEnumerable<ITraktShowTranslation>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktShowTranslation>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktShowTranslation>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktShowTranslation>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktShowTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieTranslationReader = new ShowTranslationObjectJsonReader();
                //var traktShowTranslationReadingTasks = new List<Task<ITraktShowTranslation>>();
                var traktShowTranslations = new List<ITraktShowTranslation>();

                //traktShowTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktShowTranslation traktShowTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShowTranslation != null)
                {
                    traktShowTranslations.Add(traktShowTranslation);
                    //traktShowTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktShowTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readShowTranslations = await Task.WhenAll(traktShowTranslationReadingTasks);
                //return (IEnumerable<ITraktShowTranslation>)readShowTranslations.GetEnumerator();
                return traktShowTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowTranslation>));
        }
    }
}
