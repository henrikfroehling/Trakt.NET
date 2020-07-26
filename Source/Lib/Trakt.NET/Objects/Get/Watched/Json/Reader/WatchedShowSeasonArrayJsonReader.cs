namespace TraktNet.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonArrayJsonReader : ArrayJsonReader<ITraktWatchedShowSeason>
    {
        public override async Task<IEnumerable<ITraktWatchedShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowSeasonObjectReader = new WatchedShowSeasonObjectJsonReader();
                var watchedShowSeasons = new List<ITraktWatchedShowSeason>();
                ITraktWatchedShowSeason watchedShowSeason = await watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShowSeason != null)
                {
                    watchedShowSeasons.Add(watchedShowSeason);
                    watchedShowSeason = await watchedShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return watchedShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));
        }
    }
}
