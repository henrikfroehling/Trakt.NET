namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktSyncRatingsPostResponseNotFoundSeasonArrayJsonReader : ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundSeasonObjectReader = new TraktSyncRatingsPostResponseNotFoundSeasonObjectJsonReader();
                //var syncRatingsPostResponseNotFoundSeasonReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundSeason>>();
                var syncRatingsPostResponseNotFoundSeasons = new List<ITraktSyncRatingsPostResponseNotFoundSeason>();

                //syncRatingsPostResponseNotFoundSeasonReadingTasks.Add(syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundSeason syncRatingsPostResponseNotFoundSeason = await syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundSeason != null)
                {
                    syncRatingsPostResponseNotFoundSeasons.Add(syncRatingsPostResponseNotFoundSeason);
                    //syncRatingsPostResponseNotFoundSeasonReadingTasks.Add(syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundSeason = await syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundSeasons = await Task.WhenAll(syncRatingsPostResponseNotFoundSeasonReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>)readSyncRatingsPostResponseNotFoundSeasons.GetEnumerator();
                return syncRatingsPostResponseNotFoundSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));
        }
    }
}
