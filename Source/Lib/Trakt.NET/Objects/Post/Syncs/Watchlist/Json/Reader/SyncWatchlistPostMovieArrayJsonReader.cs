namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostMovieArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPostMovie>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostMovieReader = new SyncWatchlistPostMovieObjectJsonReader();
                var syncWatchlistPostMovies = new List<ITraktSyncWatchlistPostMovie>();
                ITraktSyncWatchlistPostMovie syncWatchlistPostMovie = await syncWatchlistPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostMovie != null)
                {
                    syncWatchlistPostMovies.Add(syncWatchlistPostMovie);
                    syncWatchlistPostMovie = await syncWatchlistPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostMovie>));
        }
    }
}
