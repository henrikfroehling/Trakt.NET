namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostMovieArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPostMovie>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostMovieReader = new SyncRatingsPostMovieObjectJsonReader();
                var syncRatingsPostMovies = new List<ITraktSyncRatingsPostMovie>();
                ITraktSyncRatingsPostMovie syncRatingsPostMovie = await syncRatingsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostMovie != null)
                {
                    syncRatingsPostMovies.Add(syncRatingsPostMovie);
                    syncRatingsPostMovie = await syncRatingsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostMovie>));
        }
    }
}
