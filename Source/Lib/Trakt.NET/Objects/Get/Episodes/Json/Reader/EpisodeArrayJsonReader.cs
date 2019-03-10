namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeArrayJsonReader : AArrayJsonReader<ITraktEpisode>
    {
        public override async Task<IEnumerable<ITraktEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeReader = new EpisodeObjectJsonReader();
                var traktEpisodes = new List<ITraktEpisode>();
                ITraktEpisode traktEpisode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisode != null)
                {
                    traktEpisodes.Add(traktEpisode);
                    traktEpisode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisode>));
        }
    }
}
