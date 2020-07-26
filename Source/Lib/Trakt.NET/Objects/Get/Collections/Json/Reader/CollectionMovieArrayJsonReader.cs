namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionMovieArrayJsonReader : ArrayJsonReader<ITraktCollectionMovie>
    {
        public override async Task<IEnumerable<ITraktCollectionMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionMovieReader = new CollectionMovieObjectJsonReader();
                var collectionMovies = new List<ITraktCollectionMovie>();
                ITraktCollectionMovie collectionMovie = await collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionMovie != null)
                {
                    collectionMovies.Add(collectionMovie);
                    collectionMovie = await collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return collectionMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));
        }
    }
}
