namespace TraktApiSharp.Objects.Get.Watched.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonArrayJsonReader : IArrayJsonReader<ITraktWatchedShowSeason>
    {
        public Task<IEnumerable<ITraktWatchedShowSeason>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktWatchedShowSeason>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktWatchedShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowSeasonObjectReader = new TraktWatchedShowSeasonObjectJsonReader();
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
