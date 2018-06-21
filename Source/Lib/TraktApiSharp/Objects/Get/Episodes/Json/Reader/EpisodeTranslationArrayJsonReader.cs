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
