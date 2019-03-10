namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeTranslationArrayJsonReader : AArrayJsonReader<ITraktEpisodeTranslation>
    {
        public override async Task<IEnumerable<ITraktEpisodeTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeTranslationReader = new EpisodeTranslationObjectJsonReader();
                var traktEpisodeTranslations = new List<ITraktEpisodeTranslation>();
                ITraktEpisodeTranslation traktEpisodeTranslation = await episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisodeTranslation != null)
                {
                    traktEpisodeTranslations.Add(traktEpisodeTranslation);
                    traktEpisodeTranslation = await episodeTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktEpisodeTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeTranslation>));
        }
    }
}
