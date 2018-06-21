namespace TraktNet.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeWatchedProgressArrayJsonReader : AArrayJsonReader<ITraktEpisodeWatchedProgress>
    {
        public override async Task<IEnumerable<ITraktEpisodeWatchedProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeWatchedProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeWatchedProgressReader = new EpisodeWatchedProgressObjectJsonReader();
                //var episodeWatchedProgressReadingTasks = new List<Task<ITraktEpisodeWatchedProgress>>();
                var traktEpisodeWatchedProgresses = new List<ITraktEpisodeWatchedProgress>();

                //episodeWatchedProgressReadingTasks.Add(episodeWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = await episodeWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktEpisodeWatchedProgress != null)
                {
                    traktEpisodeWatchedProgresses.Add(traktEpisodeWatchedProgress);
                    //episodeWatchedProgressReadingTasks.Add(episodeWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktEpisodeWatchedProgress = await episodeWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readEpisodeWatchedProgresses = await Task.WhenAll(episodeWatchedProgressReadingTasks);
                //return (IEnumerable<ITraktEpisodeWatchedProgress>)readEpisodeWatchedProgresses.GetEnumerator();
                return traktEpisodeWatchedProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeWatchedProgress>));
        }
    }
}
