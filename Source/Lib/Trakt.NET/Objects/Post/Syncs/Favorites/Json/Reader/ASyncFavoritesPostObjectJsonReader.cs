namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncFavoritesPostObjectJsonReader<TSyncFavoritesPost> : AObjectJsonReader<TSyncFavoritesPost>
        where TSyncFavoritesPost : ITraktSyncFavoritesPost
    {
        public override async Task<TSyncFavoritesPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TSyncFavoritesPost syncFavoritesPost = CreateInstance();
                var syncFavoritesPostMovieArrayJsonReader = new ArrayJsonReader<ITraktSyncFavoritesPostMovie>();
                var syncFavoritesPostShowArrayJsonReader = new ArrayJsonReader<ITraktSyncFavoritesPostShow>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncFavoritesPost.Movies = await syncFavoritesPostMovieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncFavoritesPost.Shows = await syncFavoritesPostShowArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncFavoritesPost;
            }

            return await Task.FromResult(default(TSyncFavoritesPost));
        }

        protected abstract TSyncFavoritesPost CreateInstance();
    }
}
