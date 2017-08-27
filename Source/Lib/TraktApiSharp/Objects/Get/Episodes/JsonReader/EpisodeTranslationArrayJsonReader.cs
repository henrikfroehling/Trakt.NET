namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeTranslationArrayJsonReader : IArrayJsonReader<ITraktEpisodeTranslation>
    {
        public Task<IEnumerable<ITraktEpisodeTranslation>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktEpisodeTranslation>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktEpisodeTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeTranslationReader = new TraktEpisodeTranslationObjectJsonReader();
                //var episodeTranslationReadingTasks = new List<Task<ITraktEpisodeTranslation>>();
                var traktEpisodeTranslations = new List<ITraktEpisodeTranslation>();

                //episodeTranslationReadingTasks.Add(episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktEpisodeTranslation traktEpisodeTranslation = await episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisodeTranslation != null)
                {
                    traktEpisodeTranslations.Add(traktEpisodeTranslation);
                    //episodeTranslationReadingTasks.Add(episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktEpisodeTranslation = await episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readEpisodeTranslations = await Task.WhenAll(episodeTranslationReadingTasks);
                //return (IEnumerable<ITraktEpisodeTranslation>)readEpisodeTranslations.GetEnumerator();
                return traktEpisodeTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));
        }
    }
}
