namespace TraktNet.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonArrayJsonReader : AArrayJsonReader<ITraktWatchedShowSeason>
    {
        public override async Task<IEnumerable<ITraktWatchedShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowSeasonObjectReader = new WatchedShowSeasonObjectJsonReader();
                //var watchedShowSeasonReadingTasks = new List<Task<ITraktWatchedShowSeason>>();
                var watchedShowSeasons = new List<ITraktWatchedShowSeason>();

                //watchedShowSeasonReadingTasks.Add(watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedShowSeason watchedShowSeason = await watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShowSeason != null)
                {
                    watchedShowSeasons.Add(watchedShowSeason);
                    //watchedShowSeasonReadingTasks.Add(watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedShowSeason = await watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedShowSeasons = await Task.WhenAll(watchedShowSeasonReadingTasks);
                //return (IEnumerable<ITraktWatchedShowSeason>)readWatchedShowSeasons.GetEnumerator();
                return watchedShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));
        }
    }
}
