namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeIdsArrayJsonReader : AArrayJsonReader<ITraktEpisodeIds>
    {
        public override async Task<IEnumerable<ITraktEpisodeIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                var episodeIdss = new List<ITraktEpisodeIds>();
                ITraktEpisodeIds episodeIds = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeIds != null)
                {
                    episodeIdss.Add(episodeIds);
                    episodeIds = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeIds>));
        }
    }
}
