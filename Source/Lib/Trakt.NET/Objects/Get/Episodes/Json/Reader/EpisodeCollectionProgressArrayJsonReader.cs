namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCollectionProgressArrayJsonReader : AArrayJsonReader<ITraktEpisodeCollectionProgress>
    {
        public override async Task<IEnumerable<ITraktEpisodeCollectionProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeCollectionProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeCollectionProgressReader = new EpisodeCollectionProgressObjectJsonReader();
                var traktEpisodeCollectionProgresses = new List<ITraktEpisodeCollectionProgress>();
                ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = await episodeCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisodeCollectionProgress != null)
                {
                    traktEpisodeCollectionProgresses.Add(traktEpisodeCollectionProgress);
                    traktEpisodeCollectionProgress = await episodeCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktEpisodeCollectionProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeCollectionProgress>));
        }
    }
}
