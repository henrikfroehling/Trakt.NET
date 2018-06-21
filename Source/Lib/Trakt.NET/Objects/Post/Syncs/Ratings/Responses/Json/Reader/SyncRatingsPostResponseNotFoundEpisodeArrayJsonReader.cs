namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundEpisodeObjectReader = new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();
                //var syncRatingsPostResponseNotFoundEpisodeReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundEpisode>>();
                var syncRatingsPostResponseNotFoundEpisodes = new List<ITraktSyncRatingsPostResponseNotFoundEpisode>();

                //syncRatingsPostResponseNotFoundEpisodeReadingTasks.Add(syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundEpisode syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundEpisode != null)
                {
                    syncRatingsPostResponseNotFoundEpisodes.Add(syncRatingsPostResponseNotFoundEpisode);
                    //syncRatingsPostResponseNotFoundEpisodeReadingTasks.Add(syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundEpisodes = await Task.WhenAll(syncRatingsPostResponseNotFoundEpisodeReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>)readSyncRatingsPostResponseNotFoundEpisodes.GetEnumerator();
                return syncRatingsPostResponseNotFoundEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));
        }
    }
}
