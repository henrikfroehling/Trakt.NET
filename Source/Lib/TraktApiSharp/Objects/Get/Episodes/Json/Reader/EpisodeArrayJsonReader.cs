namespace TraktApiSharp.Objects.Get.Episodes.Json.Reader
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
                //var traktEpisodeReadingTasks = new List<Task<ITraktEpisode>>();
                var traktEpisodes = new List<ITraktEpisode>();

                //traktEpisodeReadingTasks.Add(episodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktEpisode traktEpisode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisode != null)
                {
                    traktEpisodes.Add(traktEpisode);
                    //traktEpisodeReadingTasks.Add(episodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktEpisode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readEpisodes = await Task.WhenAll(traktEpisodeReadingTasks);
                //return (IEnumerable<ITraktEpisode>)readEpisodes.GetEnumerator();
                return traktEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisode>));
        }
    }
}
