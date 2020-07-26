namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostMovieArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryPostMovie>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostMovieReader = new SyncHistoryPostMovieObjectJsonReader();
                var syncHistoryPostMovies = new List<ITraktSyncHistoryPostMovie>();
                ITraktSyncHistoryPostMovie syncHistoryPostMovie = await syncHistoryPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostMovie != null)
                {
                    syncHistoryPostMovies.Add(syncHistoryPostMovie);
                    syncHistoryPostMovie = await syncHistoryPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostMovie>));
        }
    }
}
