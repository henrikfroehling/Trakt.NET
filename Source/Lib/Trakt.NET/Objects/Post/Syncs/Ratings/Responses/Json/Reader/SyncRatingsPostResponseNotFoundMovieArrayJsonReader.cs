namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundMovieArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundMovieObjectReader = new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();
                //var syncRatingsPostResponseNotFoundMovieReadingTasks = new List<Task<ITraktSyncRatingsPostResponseNotFoundMovie>>();
                var syncRatingsPostResponseNotFoundMovies = new List<ITraktSyncRatingsPostResponseNotFoundMovie>();

                //syncRatingsPostResponseNotFoundMovieReadingTasks.Add(syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncRatingsPostResponseNotFoundMovie syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundMovie != null)
                {
                    syncRatingsPostResponseNotFoundMovies.Add(syncRatingsPostResponseNotFoundMovie);
                    //syncRatingsPostResponseNotFoundMovieReadingTasks.Add(syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncRatingsPostResponseNotFoundMovies = await Task.WhenAll(syncRatingsPostResponseNotFoundMovieReadingTasks);
                //return (IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>)readSyncRatingsPostResponseNotFoundMovies.GetEnumerator();
                return syncRatingsPostResponseNotFoundMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));
        }
    }
}
