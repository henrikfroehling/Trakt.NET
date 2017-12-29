namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowEpisodeArrayJsonReader : AArrayJsonReader<ITraktWatchedShowEpisode>
    {
        public override async Task<IEnumerable<ITraktWatchedShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowEpisodeObjectReader = new WatchedShowEpisodeObjectJsonReader();
                //var watchedShowEpisodeReadingTasks = new List<Task<ITraktWatchedShowEpisode>>();
                var watchedShowEpisodes = new List<ITraktWatchedShowEpisode>();

                //watchedShowEpisodeReadingTasks.Add(watchedShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedShowEpisode watchedShowEpisode = await watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShowEpisode != null)
                {
                    watchedShowEpisodes.Add(watchedShowEpisode);
                    //watchedShowEpisodeReadingTasks.Add(watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedShowEpisode = await watchedShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedShowEpisodes = await Task.WhenAll(watchedShowEpisodeReadingTasks);
                //return (IEnumerable<ITraktWatchedShowEpisode>)readWatchedShowEpisodes.GetEnumerator();
                return watchedShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShowEpisode>));
        }
    }
}
