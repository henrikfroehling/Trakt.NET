namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundSeasonArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundSeasonObjectReader = new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();
                var syncRatingsPostResponseNotFoundSeasons = new List<ITraktSyncRatingsPostResponseNotFoundSeason>();
                ITraktSyncRatingsPostResponseNotFoundSeason syncRatingsPostResponseNotFoundSeason = await syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundSeason != null)
                {
                    syncRatingsPostResponseNotFoundSeasons.Add(syncRatingsPostResponseNotFoundSeason);
                    syncRatingsPostResponseNotFoundSeason = await syncRatingsPostResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponseNotFoundSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason>));
        }
    }
}
