namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostMovieArrayJsonReader : ArrayJsonReader<ITraktSyncCollectionPostMovie>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostMovieReader = new SyncCollectionPostMovieObjectJsonReader();
                var syncCollectionPostMovies = new List<ITraktSyncCollectionPostMovie>();
                ITraktSyncCollectionPostMovie syncCollectionPostMovie = await syncCollectionPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostMovie != null)
                {
                    syncCollectionPostMovies.Add(syncCollectionPostMovie);
                    syncCollectionPostMovie = await syncCollectionPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostMovie>));
        }
    }
}
