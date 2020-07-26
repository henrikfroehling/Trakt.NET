namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundMovieArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundMovieObjectReader = new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();
                var syncRatingsPostResponseNotFoundMovies = new List<ITraktSyncRatingsPostResponseNotFoundMovie>();
                ITraktSyncRatingsPostResponseNotFoundMovie syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundMovie != null)
                {
                    syncRatingsPostResponseNotFoundMovies.Add(syncRatingsPostResponseNotFoundMovie);
                    syncRatingsPostResponseNotFoundMovie = await syncRatingsPostResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponseNotFoundMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie>));
        }
    }
}
