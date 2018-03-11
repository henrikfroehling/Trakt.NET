namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundSeasonArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundSeasonObjectReader = new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();
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
